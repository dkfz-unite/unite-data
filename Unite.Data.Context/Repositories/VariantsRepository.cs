using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Unite.Data.Context.Repositories.Constants;
using Unite.Data.Entities.Genome.Analysis.Dna;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Essentials.Extensions;

using Ssm = Unite.Data.Entities.Genome.Analysis.Dna.Ssm;
using Cnv = Unite.Data.Entities.Genome.Analysis.Dna.Cnv;
using Sv = Unite.Data.Entities.Genome.Analysis.Dna.Sv;

namespace Unite.Data.Context.Repositories;

public class VariantsRepository : Repository
{
    private readonly Expression<Func<Cnv.AffectedTranscript, Cnv.Variant>> _affectedTranscriptCnv = affectedFeature => affectedFeature.Variant;
    private readonly Expression<Func<Cnv.VariantEntry, Cnv.Variant>> _variantEntryCnv = entry => entry.Entity;


    public VariantsRepository(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }


    public async Task<int[]> GetRelatedProjects<TV>(IEnumerable<int> ids)
    {
        var donors = await GetRelatedDonors<TV>(ids);

        return await GetDonorRelatedProjects(donors);
    }

    public async Task<int[]> GetRelatedDonors<TV>(IEnumerable<int> ids)
    {
        var type = typeof(TV);

        if (type == typeof(Ssm.Variant))
            return await GetRelatedDonors<Ssm.VariantEntry, Ssm.Variant>(ids);
        else if (type == typeof(Cnv.Variant))
            return await GetRelatedDonors<Cnv.VariantEntry, Cnv.Variant>(ids);
        else if (type == typeof(Sv.Variant))
            return await GetRelatedDonors<Sv.VariantEntry, Sv.Variant>(ids);
        else
            return [];
    }

    public async Task<int[]> GetRelatedDonors<TVE, TV>(IEnumerable<int> ids)
        where TVE : VariantEntry<TV>
        where TV : Variant
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<TVE>()
            .AsNoTracking()
            .Where(entry => ids.Contains(entry.EntityId))
            .Select(entry => entry.Sample.Specimen.DonorId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedImages<TV>(IEnumerable<int> ids, ImageType? typeId = null)
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

    public async Task<int[]> GetRelatedSpecimens<TV>(IEnumerable<int> ids, SpecimenType? typeId = null)
        where TV : Variant
    {
        var type = typeof(TV);

        if (type == typeof(Ssm.Variant))
            return await GetRelatedSpecimens<Ssm.VariantEntry, Ssm.Variant>(ids, typeId);
        else if (type == typeof(Cnv.Variant))
            return await GetRelatedSpecimens<Cnv.VariantEntry, Cnv.Variant>(ids, typeId);
        else if (type == typeof(Sv.Variant))
            return await GetRelatedSpecimens<Sv.VariantEntry, Sv.Variant>(ids, typeId);
        else
            return [];
    }

    public async Task<int[]> GetRelatedSpecimens<TVE, TV>(IEnumerable<int> ids, SpecimenType? typeId = null)
        where TVE : VariantEntry<TV>
        where TV : Variant
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var predicate = typeof(TV) == typeof(Cnv.Variant)
            ? _variantEntryCnv.Join(Predicates.IsInfluentCnv) as Expression<Func<TVE, bool>>
            : entry => true;

        return await dbContext.Set<TVE>()
            .AsNoTracking()
            .Where(predicate)
            .Where(entry => typeId == null || entry.Sample.Specimen.TypeId == typeId)
            .Where(entry => ids.Contains(entry.EntityId))
            .Select(entry => entry.Sample.SpecimenId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedGenes<TV>(IEnumerable<int> ids)
    {
        var type = typeof(TV);

        if (type == typeof(Ssm.Variant))
            return await GetRelatedGenes<Ssm.AffectedTranscript, Ssm.Variant>(ids);
        else if (type == typeof(Cnv.Variant))
            return await GetRelatedGenes<Cnv.AffectedTranscript, Cnv.Variant>(ids);
        else if (type == typeof(Sv.Variant))
            return await GetRelatedGenes<Sv.AffectedTranscript, Sv.Variant>(ids);
        else
            return [];
    }

    public async Task<int[]> GetRelatedGenes<TVAT, TV>(IEnumerable<int> ids)
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
            .Where(affectedFeature => ids.Contains(affectedFeature.VariantId))
            .Where(affectedFeature => affectedFeature.Feature.GeneId != null)
            .Select(affectedFeature => affectedFeature.Feature.GeneId.Value)
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedTranscripts<TV>(IEnumerable<int> ids)
    {
        var type = typeof(TV);

        if (type == typeof(Ssm.Variant))
            return await GetRelatedTranscripts<Ssm.AffectedTranscript, Ssm.Variant>(ids);
        else if (type == typeof(Cnv.Variant))
            return await GetRelatedTranscripts<Cnv.AffectedTranscript, Cnv.Variant>(ids);
        else if (type == typeof(Sv.Variant))
            return await GetRelatedTranscripts<Sv.AffectedTranscript, Sv.Variant>(ids);
        else
            return [];
    }

    public async Task<int[]> GetRelatedTranscripts<TVAT, TV>(IEnumerable<int> ids)
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
            .Where(affectedFeature => ids.Contains(affectedFeature.VariantId))
            .Select(affectedFeature => affectedFeature.FeatureId)
            .ToArrayAsync();
    }
}
