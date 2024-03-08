using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Unite.Data.Context.Repositories.Constants;
using Unite.Data.Entities.Genome.Variants;
using Unite.Data.Entities.Genome.Transcriptomics;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Specimens;
using Unite.Essentials.Extensions;

using SSM = Unite.Data.Entities.Genome.Variants.SSM;
using CNV = Unite.Data.Entities.Genome.Variants.CNV;
using SV = Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Context.Repositories;

public class SpecimensRepository : Repository
{
    private readonly Expression<Func<CNV.VariantEntry, CNV.Variant>> _variantEntryCnv = entry => entry.Entity;
    private readonly VariantsRepository _variantsRepository;


    public SpecimensRepository(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
    {
        _variantsRepository = new VariantsRepository(dbContextFactory);
    }


    public async Task<int[]> GetRelatedProjects(IEnumerable<int> ids)
    {
        var donors = await GetRelatedDonors(ids);

        return await GetDonorRelatedProjects(donors);
    }

    public async Task<int[]> GetRelatedDonors(IEnumerable<int> ids)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<Specimen>()
            .AsNoTracking()
            .Where(specimen => ids.Contains(specimen.Id))
            .Select(specimen => specimen.DonorId)
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedImages(IEnumerable<int> ids, ImageType? typeId = null)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var donors = await GetRelatedDonors(ids);

        return await dbContext.Set<Image>()
            .AsNoTracking()
            .Where(image => typeId == null || image.TypeId == typeId)
            .Where(image => ids.Contains(image.DonorId))
            .Select(image => image.Id)
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedGenes(IEnumerable<int> ids)
    {
        var results = await Task.WhenAll
        (
            GetVariantRelatedGenes(ids),
            GetExpressionRelatedGenes(ids)
        );

        return results
            .SelectMany(result => result)
            .Distinct()
            .ToArray();
    }

    public async Task<int[]> GetVariantRelatedGenes(IEnumerable<int> ids)
    {
        var results = await Task.WhenAll
        (
            GetVariantRelatedGenes<SSM.Variant>(ids),
            GetVariantRelatedGenes<CNV.Variant>(ids),
            GetVariantRelatedGenes<SV.Variant>(ids)
        );

        return results
            .SelectMany(result => result)
            .Distinct()
            .ToArray();
    }

    public async Task<int[]> GetVariantRelatedGenes<TV>(IEnumerable<int> ids)
        where TV : Variant
    {
        var variants = await GetRelatedVariants<TV>(ids);

        return await _variantsRepository.GetRelatedGenes<TV>(variants);
    }

    public async Task<int[]> GetExpressionRelatedGenes(IEnumerable<int> ids)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<BulkExpression>()
            .AsNoTracking()
            .Where(expression => ids.Contains(expression.AnalysedSampleId))
            .Select(expression => expression.EntityId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<long[]> GetRelatedVariants<TV>(IEnumerable<int> ids)
    {
        var type = typeof(TV);

        if (type == typeof(SSM.Variant))
            return await GetRelatedVariants<SSM.VariantEntry, SSM.Variant>(ids);
        else if (type == typeof(CNV.Variant))
            return await GetRelatedVariants<CNV.VariantEntry, CNV.Variant>(ids);
        else if (type == typeof(SV.Variant))
            return await GetRelatedVariants<SV.VariantEntry, SV.Variant>(ids);
        else
            return [];
    }

    public async Task<long[]> GetRelatedVariants<TVE, TV>(IEnumerable<int> ids)
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
                .Where(entry => ids.Contains(entry.AnalysedSample.TargetSampleId))
                .Select(entry => entry.EntityId)
                .ToArrayAsync();
    }
}
