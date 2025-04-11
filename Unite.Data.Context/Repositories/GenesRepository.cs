using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Unite.Data.Context.Repositories.Constants;
using Unite.Data.Entities.Genome.Analysis.Rna;
using Unite.Data.Entities.Genome.Analysis.Dna;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Essentials.Extensions;

using Sm = Unite.Data.Entities.Genome.Analysis.Dna.Sm;
using Cnv = Unite.Data.Entities.Genome.Analysis.Dna.Cnv;
using Sv = Unite.Data.Entities.Genome.Analysis.Dna.Sv;

namespace Unite.Data.Context.Repositories;

public class GenesRepository : Repository
{
    private readonly Expression<Func<Cnv.AffectedTranscript, Cnv.Variant>> _affectedTranscriptCnv = affectedFeature => affectedFeature.Variant;
    private readonly SpecimensRepository _specimensRepository;


    public GenesRepository(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
    {
        _specimensRepository = new SpecimensRepository(dbContextFactory);
    }


    public async Task<int[]> GetRelatedProjects(IEnumerable<int> ids)
    {
        var donors = await GetRelatedDonors(ids);

        return await GetDonorRelatedProjects(donors);
    }

    public async Task<int[]> GetRelatedDonors(IEnumerable<int> ids)
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedDonors(specimens);
    }

    public async Task<int[]> GetRelatedImages(IEnumerable<int> ids, ImageType? typeId = null)
    {
        var specimens = await GetRelatedSpecimens(ids, SpecimenType.Material);

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
            GetVariantRelatedSpecimens<Sm.Variant>(ids, typeId),
            GetVariantRelatedSpecimens<Cnv.Variant>(ids, typeId),
            GetVariantRelatedSpecimens<Sv.Variant>(ids, typeId)
        );

        return results
            .SelectMany(result => result)
            .Distinct()
            .ToArray();
    }

    public async Task<int[]> GetVariantRelatedSpecimens<TV>(IEnumerable<int> ids, SpecimenType? typeId = null)
    {
        var type = typeof(TV);

        if (type == typeof(Sm.Variant))
            return await GetVariantRelatedSpecimens<Sm.VariantEntry, Sm.Variant>(ids, typeId);
        else if (type == typeof(Cnv.Variant))
            return await GetVariantRelatedSpecimens<Cnv.VariantEntry, Cnv.Variant>(ids, typeId);
        else if (type == typeof(Sv.Variant))
            return await GetVariantRelatedSpecimens<Sv.VariantEntry, Sv.Variant>(ids, typeId);
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
            .Where(entry => typeId == null || entry.Sample.Specimen.TypeId == typeId)
            .Where(entry => variants.Contains(entry.EntityId))
            .Select(entry => entry.Sample.SpecimenId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<int[]> GetExpressionRelatedSpecimens(IEnumerable<int> ids, SpecimenType? typeId = null)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<GeneExpression>()
            .AsNoTracking()
            .Where(expression => typeId == null || expression.Sample.Specimen.TypeId == typeId)
            .Where(expression => ids.Contains(expression.EntityId))
            .Select(expression => expression.Sample.SpecimenId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedVariants<TV>(IEnumerable<int> ids)
    {
        var type = typeof(TV);

        if (type == typeof(Sm.Variant))
            return await GetRelatedVariants<Sm.AffectedTranscript, Sm.Variant>(ids);
        else if (type == typeof(Cnv.Variant))
            return await GetRelatedVariants<Cnv.AffectedTranscript, Cnv.Variant>(ids);
        else if (type == typeof(Sv.Variant))
            return await GetRelatedVariants<Sv.AffectedTranscript, Sv.Variant>(ids);
        else
            return [];
    }

    public async Task<int[]> GetRelatedVariants<TVAT, TV>(IEnumerable<int> ids)
        where TVAT : VariantAffectedTranscript<TV>
        where TV : Variant
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var predicate = typeof(TV) == typeof(Cnv.Variant)
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
