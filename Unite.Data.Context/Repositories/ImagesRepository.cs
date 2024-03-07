using Microsoft.EntityFrameworkCore;
using Unite.Data.Context.Repositories.Constants;
using Unite.Data.Entities.Genome.Variants;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Context.Repositories;

public class ImagesRepository
{
    private readonly IDbContextFactory<DomainDbContext> _dbContextFactory;
    private readonly SpecimensRepository _specimensRepository;


    public ImagesRepository(IDbContextFactory<DomainDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
        _specimensRepository = new SpecimensRepository(dbContextFactory);
    }


    public async Task<int[]> GetRelatedProjects(IEnumerable<int> ids)
    {
        var donors = await GetRelatedDonors(ids);

        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<Entities.Donors.ProjectDonor>()
            .AsNoTracking()
            .Where(projectDonor => donors.Contains(projectDonor.DonorId))
            .Select(projectDonor => projectDonor.ProjectId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedDonors(IEnumerable<int> ids)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<Image>()
            .AsNoTracking()
            .Where(image => ids.Contains(image.Id))
            .Select(image => image.DonorId)
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedSpecimens(IEnumerable<int> ids)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var donors = await GetRelatedDonors(ids);

        return await dbContext.Set<Specimen>()
            .AsNoTracking()
            .Include(specimen => specimen.Material)
            .Where(Predicates.IsImageRelatedSpecimen)
            .Where(specimen => donors.Contains(specimen.DonorId))
            .Select(specimen => specimen.Id)
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedGenes(IEnumerable<int> ids)
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedGenes(specimens);
    }

    public async Task<int[]> GetVariantRelatedGenes(IEnumerable<int> ids)
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetVariantRelatedGenes(specimens);
    }

    public async Task<int[]> GetVariantRelatedGenes<TV>(IEnumerable<int> ids)
        where TV : Variant
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetVariantRelatedGenes<TV>(specimens);
    }

    public async Task<int[]> GetExpressionRelatedGenes(IEnumerable<int> ids)
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetExpressionRelatedGenes(specimens);
    }

    public async Task<long[]> GetRelatedVariants<TV>(IEnumerable<int> ids)
        where TV : Variant    
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedVariants<TV>(specimens);
    }
}
