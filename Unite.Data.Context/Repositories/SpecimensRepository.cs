using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Unite.Essentials.Extensions;
using Unite.Data.Context.Repositories.Constants;
using Unite.Data.Entities.Omics.Analysis.Dna;
using Unite.Data.Entities.Omics.Analysis.Rna;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Enums;

using Sm = Unite.Data.Entities.Omics.Analysis.Dna.Sm;
using Cnv = Unite.Data.Entities.Omics.Analysis.Dna.Cnv;
using Sv = Unite.Data.Entities.Omics.Analysis.Dna.Sv;

namespace Unite.Data.Context.Repositories;

public class SpecimensRepository : Repository
{
    private readonly Expression<Func<Cnv.VariantEntry, Cnv.Variant>> _variantEntryCnv = entry => entry.Entity;
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

    public async Task<int[]> GetRelatedSpecimens(IEnumerable<int> ids, SpecimenType? typeId = null)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await GetChildSpecimens(dbContext, ids, typeId);
    }

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Specimens.Analysis.Enums.AnalysisType> typeIds = null)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var filterByTypes = typeIds?.IsNotEmpty() ?? false;

        return await dbContext.Set<Entities.Specimens.Analysis.Sample>()
            .AsNoTracking()
            .Where(sample => ids.Contains(sample.SpecimenId))
            .Where(sample => !filterByTypes || typeIds.Contains(sample.Analysis.TypeId))
            .Select(sample => sample.Id)
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Omics.Analysis.Enums.AnalysisType> typeIds = null)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var filterByTypes = typeIds?.IsNotEmpty() ?? false;

        return await dbContext.Set<Entities.Omics.Analysis.Sample>()
            .AsNoTracking()
            .Where(sample => ids.Contains(sample.SpecimenId))
            .Where(sample => !filterByTypes || typeIds.Contains(sample.Analysis.TypeId))
            .Select(sample => sample.Id)
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
            GetVariantRelatedGenes<Sm.Variant>(ids),
            GetVariantRelatedGenes<Cnv.Variant>(ids),
            GetVariantRelatedGenes<Sv.Variant>(ids)
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

        return await dbContext.Set<GeneExpression>()
            .AsNoTracking()
            .Where(expression => ids.Contains(expression.SampleId))
            .Select(expression => expression.EntityId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedVariants<TV>(IEnumerable<int> ids)
    {
        var type = typeof(TV);

        if (type == typeof(Sm.Variant))
            return await GetRelatedVariants<Sm.VariantEntry, Sm.Variant>(ids);
        else if (type == typeof(Cnv.Variant))
            return await GetRelatedVariants<Cnv.VariantEntry, Cnv.Variant>(ids);
        else if (type == typeof(Sv.Variant))
            return await GetRelatedVariants<Sv.VariantEntry, Sv.Variant>(ids);
        else
            return [];
    }

    public async Task<int[]> GetRelatedVariants<TVE, TV>(IEnumerable<int> ids)
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
                .Where(entry => ids.Contains(entry.Sample.SpecimenId))
                .Select(entry => entry.EntityId)
                .ToArrayAsync();
    }


    private async Task<int[]> GetChildSpecimens(DomainDbContext dbContext, IEnumerable<int> ids, SpecimenType? typeId = null)
    {
        var specimens = await dbContext.Set<Specimen>()
            .AsNoTracking()
            .Where(specimen => typeId == null || specimen.TypeId == typeId)
            .Where(specimen => specimen.ParentId != null)
            .Where(specimen => ids.Contains(specimen.ParentId.Value))
            .Select(specimen => specimen.Id)
            .ToListAsync();

        if (specimens.IsNotEmpty())
        {
            specimens.AddRange(await GetChildSpecimens(dbContext, specimens, typeId));
        }

        return specimens.ToArray();
    }
}
