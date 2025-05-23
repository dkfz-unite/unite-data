using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Omics.Analysis.Dna;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Repositories;

public class DonorsRepository : Repository
{
    private readonly ImagesRepository _imagesRepository;
    private readonly SpecimensRepository _specimensRepository;
    

    public DonorsRepository(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
    {
        _imagesRepository = new ImagesRepository(dbContextFactory);
        _specimensRepository = new SpecimensRepository(dbContextFactory);
    }


    public async Task<int[]> GetRelatedProjects(IEnumerable<int> ids)
    {
        return await GetDonorRelatedProjects(ids);
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

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Images.Analysis.Enums.AnalysisType> typeIds = null)
    {
        var images = await GetRelatedImages(ids);

        return await _imagesRepository.GetRelatedSamples(images, typeIds);
    }

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Specimens.Analysis.Enums.AnalysisType> typeIds = null)
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedSamples(specimens, typeIds);
    }

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Omics.Analysis.Enums.AnalysisType> typeIds = null)
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedSamples(specimens, typeIds);
    }

    public async Task<int[]> GetRelatedGenes(IEnumerable<int> ids)
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedGenes(specimens);
    }

    public async Task<int[]> GetRelatedVariants<TV>(IEnumerable<int> ids)
        where TV : Variant
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedVariants<TV>(specimens);
    }
}
