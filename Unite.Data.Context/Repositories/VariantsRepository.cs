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

    public async Task<int[]> GetSimilarVariants<TV>(IEnumerable<int> ids, double overlap = 0.9)
        where TV : Variant
    {
        if (typeof(TV) == typeof(Cnv.Variant))
            return await GetSimilarCnvs(ids, overlap);
        else if (typeof(TV) == typeof(Sv.Variant))
            return await GetSimilarSvs(ids, overlap);
        else
            return [];
    }


    private async Task<int[]> GetSimilarCnvs(IEnumerable<int> ids, double overlap)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var results = new List<int>();

        var targets = await dbContext.Set<Cnv.Variant>()
            .AsNoTracking()
            .Where(variant => ids.Contains(variant.Id))
            .ToArrayAsync();

        foreach (var target in targets)
        {
            await dbContext.Set<Cnv.Variant>()
                .AsNoTracking()
                .Where(Predicates.IsInfluentCnv)
                .Where(current =>
                    current.Id != target.Id &&
                    current.TypeId == target.TypeId &&
                    current.Loh == target.Loh &&
                    current.Del == target.Del &&
                    current.End >= target.Start &&
                    current.Start <= target.End
                )
                .Select(current => new 
                {
                    Id = current.Id,
                    OverlapStart = Math.Max(current.Start, target.Start),
                    OverlapEnd = Math.Min(current.End, target.End),
                    CurrentLength = current.End - current.Start,
                    TargetLength = target.End - target.Start
                })
                .Where(current => Math.Min(
                    (double)(current.OverlapEnd - current.OverlapStart) / current.CurrentLength,
                    (double)(current.OverlapEnd - current.OverlapStart) / current.TargetLength
                ) >= overlap)
                .Select(current => current.Id)
                .ToArrayAsync();
        }

        return results.ToArray();
    }

    private async Task<int[]> GetSimilarSvs(IEnumerable<int> ids, double overlap)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var results = new List<int>();

        var targets = await dbContext.Set<Sv.Variant>()
            .AsNoTracking()
            .Where(variant => ids.Contains(variant.Id))
            .ToArrayAsync();

        foreach (var target in targets)
        {
            if (target.TypeId == Sv.Enums.SvType.ITX || target.TypeId == Sv.Enums.SvType.CTX)
            {
                var distance = 5000;
                var targetStartMin = Math.Max(0, target.End - distance);
                var targetStartMax = target.End + distance;
                var targetEndMin = Math.Max(0, target.OtherStart - distance);
                var targetEndMax = target.OtherStart + distance;

                results.AddRange(await dbContext.Set<Sv.Variant>()
                    .AsNoTracking()
                    .Where(current =>
                        current.Id != target.Id &&
                        current.TypeId == target.TypeId &&
                        current.Inverted == target.Inverted &&
                        current.ChromosomeId == target.ChromosomeId &&
                        current.OtherChromosomeId == target.OtherChromosomeId &&
                        current.End >= targetStartMin &&
                        current.End <= targetStartMax &&
                        current.OtherStart >= targetEndMin &&
                        current.OtherStart <= targetEndMax
                    )
                    .Select(current => current.Id)
                    .ToArrayAsync());
            }
            else
            {
                results.AddRange(await dbContext.Set<Sv.Variant>()
                    .AsNoTracking()
                    .Where(current =>
                        current.Id != target.Id &&
                        current.TypeId == target.TypeId &&
                        current.Inverted == target.Inverted &&
                        current.End >= target.Start &&
                        current.Start <= target.End
                    )
                    .Select(current => new 
                    {
                        Id = current.Id,
                        OverlapStart = Math.Max(current.End, target.End),
                        OverlapEnd = Math.Min(current.OtherStart, target.OtherStart),
                        CurrentLength = current.OtherStart - current.End,
                        TargetLength = target.OtherStart - target.End
                    })
                    .Where(current => Math.Min(
                        (double)(current.OverlapEnd - current.OverlapStart) / current.CurrentLength,
                        (double)(current.OverlapEnd - current.OverlapStart) / current.TargetLength
                    ) >= overlap)
                    .Select(current => current.Id)
                    .ToArrayAsync());
            }
        }

        return results.ToArray();
    }
}
