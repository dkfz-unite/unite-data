using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Unite.Data.Context.Repositories.Constants;
using Unite.Data.Entities.Genome.Variants;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Essentials.Extensions;

using SSM = Unite.Data.Entities.Genome.Variants.SSM;
using CNV = Unite.Data.Entities.Genome.Variants.CNV;
using SV = Unite.Data.Entities.Genome.Variants.SV;


namespace Unite.Data.Context.Repositories;

public class VariantsRepository
{
    private readonly Expression<Func<CNV.AffectedTranscript, CNV.Variant>> _affectedTranscriptCnv = affectedFeature => affectedFeature.Variant;
    private readonly Expression<Func<CNV.VariantEntry, CNV.Variant>> _variantEntryCnv = entry => entry.Entity;

    private readonly IDbContextFactory<DomainDbContext> _dbContextFactory;


    public VariantsRepository(IDbContextFactory<DomainDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }


    public async Task<int[]> GetRelatedDonors<TV>(IEnumerable<long> ids)
    {
        var type = typeof(TV);

        if (type == typeof(SSM.Variant))
            return await GetRelatedDonors<SSM.VariantEntry, SSM.Variant>(ids);
        else if (type == typeof(CNV.Variant))
            return await GetRelatedDonors<CNV.VariantEntry, CNV.Variant>(ids);
        else if (type == typeof(SV.Variant))
            return await GetRelatedDonors<SV.VariantEntry, SV.Variant>(ids);
        else
            return [];
    }

    public async Task<int[]> GetRelatedDonors<TVE, TV>(IEnumerable<long> ids)
        where TVE : VariantEntry<TV>
        where TV : Variant
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<TVE>()
            .AsNoTracking()
            .Where(entry => ids.Contains(entry.EntityId))
            .Select(entry => entry.AnalysedSample.TargetSample.DonorId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedImages<TV>(IEnumerable<long> ids, ImageType? typeId = null)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var donors = await GetRelatedDonors<TV>(ids);

        return await dbContext.Set<Image>()
            .AsNoTracking()
            .Where(image => typeId == null || image.TypeId == typeId)
            .Where(image => donors.Contains(image.DonorId))
            .Select(image => image.Id)
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedSpecimens<TV>(IEnumerable<long> ids, SpecimenType? typeId = null)
        where TV : Variant
    {
        var type = typeof(TV);

        if (type == typeof(SSM.Variant))
            return await GetRelatedSpecimens<SSM.VariantEntry, SSM.Variant>(ids, typeId);
        else if (type == typeof(CNV.Variant))
            return await GetRelatedSpecimens<CNV.VariantEntry, CNV.Variant>(ids, typeId);
        else if (type == typeof(SV.Variant))
            return await GetRelatedSpecimens<SV.VariantEntry, SV.Variant>(ids, typeId);
        else
            return [];
    }

    public async Task<int[]> GetRelatedSpecimens<TVE, TV>(IEnumerable<long> ids, SpecimenType? typeId = null)
        where TVE : VariantEntry<TV>
        where TV : Variant
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var predicate = typeof(TV) == typeof(CNV.Variant)
            ? _variantEntryCnv.Join(Predicates.IsInfluentCnv) as Expression<Func<TVE, bool>>
            : entry => true;

        return await dbContext.Set<TVE>()
            .AsNoTracking()
            .Where(predicate)
            .Where(entry => typeId == null || entry.AnalysedSample.TargetSample.TypeId == typeId)
            .Where(entry => ids.Contains(entry.EntityId))
            .Select(entry => entry.AnalysedSample.TargetSampleId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedGenes<TV>(IEnumerable<long> ids)
    {
        var type = typeof(TV);

        if (type == typeof(SSM.Variant))
            return await GetRelatedGenes<SSM.AffectedTranscript, SSM.Variant>(ids);
        else if (type == typeof(CNV.Variant))
            return await GetRelatedGenes<CNV.AffectedTranscript, CNV.Variant>(ids);
        else if (type == typeof(SV.Variant))
            return await GetRelatedGenes<SV.AffectedTranscript, SV.Variant>(ids);
        else
            return [];
    }

    public async Task<int[]> GetRelatedGenes<TVAT, TV>(IEnumerable<long> ids)
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
            .Where(affectedFeature => ids.Contains(affectedFeature.VariantId))
            .Where(affectedFeature => affectedFeature.Feature.GeneId != null)
            .Select(affectedFeature => affectedFeature.Feature.GeneId.Value)
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedTranscripts<TV>(IEnumerable<long> ids)
    {
        var type = typeof(TV);

        if (type == typeof(SSM.Variant))
            return await GetRelatedTranscripts<SSM.AffectedTranscript, SSM.Variant>(ids);
        else if (type == typeof(CNV.Variant))
            return await GetRelatedTranscripts<CNV.AffectedTranscript, CNV.Variant>(ids);
        else if (type == typeof(SV.Variant))
            return await GetRelatedTranscripts<SV.AffectedTranscript, SV.Variant>(ids);
        else
            return [];
    }

    public async Task<int[]> GetRelatedTranscripts<TVAT, TV>(IEnumerable<long> ids)
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
            .Where(affectedFeature => ids.Contains(affectedFeature.VariantId))
            .Select(affectedFeature => affectedFeature.FeatureId)
            .ToArrayAsync();
    }
}
