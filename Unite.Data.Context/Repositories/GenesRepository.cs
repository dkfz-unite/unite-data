using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Unite.Data.Context.Repositories.Constants;
using Unite.Data.Entities.Genome.Transcriptomics;
using Unite.Data.Entities.Genome.Variants;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Essentials.Extensions;

using SSM = Unite.Data.Entities.Genome.Variants.SSM;
using CNV = Unite.Data.Entities.Genome.Variants.CNV;
using SV = Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Context.Repositories;

public class GenesRepository
{
    private readonly Expression<Func<CNV.AffectedTranscript, CNV.Variant>> _affectedTranscriptCnv = affectedFeature => affectedFeature.Variant;

    private readonly IDbContextFactory<DomainDbContext> _dbContextFactory;
    private readonly SpecimensRepository _specimensRepository;


    public GenesRepository(IDbContextFactory<DomainDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
        _specimensRepository = new SpecimensRepository(dbContextFactory);
    }


    public async Task<int[]> GetRelatedDonors(IEnumerable<int> ids)
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedDonors(specimens);
    }

    public async Task<int[]> GetRelatedImages(IEnumerable<int> ids, ImageType? typeId = null)
    {
        var specimens = await GetRelatedSpecimens(ids, SpecimenType.Tissue);

        return await _specimensRepository.GetRelatedImages(specimens, typeId);
    }

    public async Task<int[]> GetRelatedSpecimens(IEnumerable<int> ids, SpecimenType? typeId = null)
    {
        var results = await Task.WhenAll
        (
            GetVariantRelatedSpecimens(ids, typeId),
            GetExpressionRelatedSpecimens(ids, typeId)
        );

        return results
            .SelectMany(result => result)
            .Distinct()
            .ToArray();
    }

    public async Task<int[]> GetVariantRelatedSpecimens(IEnumerable<int> ids, SpecimenType? typeId = null)
    {
        var results = await Task.WhenAll
        (
            GetVariantRelatedSpecimens<SSM.Variant>(ids, typeId),
            GetVariantRelatedSpecimens<CNV.Variant>(ids, typeId),
            GetVariantRelatedSpecimens<SV.Variant>(ids, typeId)
        );

        return results
            .SelectMany(result => result)
            .Distinct()
            .ToArray();
    }

    public async Task<int[]> GetVariantRelatedSpecimens<TV>(IEnumerable<int> ids, SpecimenType? typeId = null)
    {
        var type = typeof(TV);

        if (type == typeof(SSM.Variant))
            return await GetVariantRelatedSpecimens<SSM.VariantEntry, SSM.Variant>(ids, typeId);
        else if (type == typeof(CNV.Variant))
            return await GetVariantRelatedSpecimens<CNV.VariantEntry, CNV.Variant>(ids, typeId);
        else if (type == typeof(SV.Variant))
            return await GetVariantRelatedSpecimens<SV.VariantEntry, SV.Variant>(ids, typeId);
        else
            return [];
    }

    public async Task<int[]> GetVariantRelatedSpecimens<TVE, TV>(IEnumerable<int> ids, SpecimenType? typeId = null)
        where TVE : VariantEntry<TV>
        where TV : Variant
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var variants = await GetRelatedVariants<TV>(ids);

        return await dbContext.Set<TVE>()
            .AsNoTracking()
            .Where(entry => typeId == null || entry.AnalysedSample.TargetSample.TypeId == typeId)
            .Where(entry => variants.Contains(entry.EntityId))
            .Select(entry => entry.AnalysedSample.TargetSampleId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<int[]> GetExpressionRelatedSpecimens(IEnumerable<int> ids, SpecimenType? typeId = null)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<BulkExpression>()
            .AsNoTracking()
            .Where(expression => typeId == null || expression.AnalysedSample.TargetSample.TypeId == typeId)
            .Where(expression => ids.Contains(expression.EntityId))
            .Select(expression => expression.AnalysedSample.TargetSampleId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<long[]> GetRelatedVariants<TV>(IEnumerable<int> ids)
    {
        var type = typeof(TV);

        if (type == typeof(SSM.Variant))
            return await GetRelatedVariants<SSM.AffectedTranscript, SSM.Variant>(ids);
        else if (type == typeof(CNV.Variant))
            return await GetRelatedVariants<CNV.AffectedTranscript, CNV.Variant>(ids);
        else if (type == typeof(SV.Variant))
            return await GetRelatedVariants<SV.AffectedTranscript, SV.Variant>(ids);
        else
            return [];
    }

    public async Task<long[]> GetRelatedVariants<TVAT, TV>(IEnumerable<int> ids)
        where TVAT : VariantAffectedTranscript<TV>
        where TV : Variant
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var predicate = typeof(TV) == typeof(CNV.Variant)
            ? _affectedTranscriptCnv.Join(Predicates.IsInfluentCnv) as Expression<Func<TVAT, bool>> 
            : affectedFeature => true;

        return await dbContext.Set<TVAT>()
            .AsNoTracking()
            .Where(predicate)
            .Where(affectedFeature => affectedFeature.Feature.GeneId != null)
            .Where(affectedFeature => ids.Contains(affectedFeature.Feature.GeneId.Value))
            .Select(affectedFeature => affectedFeature.VariantId)
            .ToArrayAsync();
    }
}
