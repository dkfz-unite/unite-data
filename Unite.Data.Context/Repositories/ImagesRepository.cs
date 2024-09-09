using Microsoft.EntityFrameworkCore;
using Unite.Data.Context.Repositories.Constants;
using Unite.Data.Entities.Genome.Analysis.Dna;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Specimens;
using Unite.Essentials.Extensions;

namespace Unite.Data.Context.Repositories;

public class ImagesRepository : Repository
{
    private readonly SpecimensRepository _specimensRepository;


    public ImagesRepository(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
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

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Images.Analysis.Enums.AnalysisType> typeIds = null)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var filterByTypes = typeIds?.IsNotEmpty() ?? false;

        return await dbContext.Set<Entities.Images.Analysis.Sample>()
            .AsNoTracking()
            .Where(sample => ids.Contains(sample.SpecimenId))
            .Where(sample => !filterByTypes || typeIds.Contains(sample.Analysis.TypeId.Value))
            .Select(sample => sample.Id)
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Specimens.Analysis.Enums.AnalysisType> typeIds = null)
    {
        var specimenIds = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedSamples(specimenIds, typeIds);
    }

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Genome.Analysis.Enums.AnalysisType> typeIds)
    {
        var specimenIds = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedSamples(specimenIds, typeIds);
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

    public async Task<int[]> GetRelatedVariants<TV>(IEnumerable<int> ids)
        where TV : Variant    
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedVariants<TV>(specimens);
    }
}
