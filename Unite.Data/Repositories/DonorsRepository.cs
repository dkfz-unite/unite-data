using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Genome.Variants;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services;

namespace Unite.Data.Repositories;

public class DonorsRepository
{
    private readonly IDbContextFactory<DomainDbContext> _dbContextFactory;
    private readonly SpecimensRepository _specimensRepository;
    

    public DonorsRepository(IDbContextFactory<DomainDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
        _specimensRepository = new SpecimensRepository(dbContextFactory);
    }


    public async Task<int[]> GetRelatedImages(IEnumerable<int> ids, ImageType? typeId = null)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

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

        return await dbContext.Set<Specimen>()
            .AsNoTracking()
            .Where(specimen => typeId == null || specimen.TypeId == typeId)
            .Where(specimen => ids.Contains(specimen.DonorId))
            .Select(specimen => specimen.Id)
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedGenes(IEnumerable<int> ids)
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedGenes(specimens);
    }

    public async Task<long[]> GetRelatedVariants<TV>(IEnumerable<int> ids)
        where TV : Variant
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedVariants<TV>(specimens);
    }
}
