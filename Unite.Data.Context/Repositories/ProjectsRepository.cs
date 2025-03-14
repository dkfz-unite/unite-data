using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Genome.Analysis.Dna;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Repositories;

public class ProjectsRepository : Repository
{
    private readonly DonorsRepository _donorsRepository;


    public ProjectsRepository(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
    {
        _donorsRepository = new DonorsRepository(dbContextFactory);
    }


    public async Task<int[]> GetRelatedDonors(IEnumerable<int> ids)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<Entities.Donors.ProjectDonor>()
            .AsNoTracking()
            .Where(projectDonor => ids.Contains(projectDonor.ProjectId))
            .Select(projectDonor => projectDonor.DonorId)
            .Distinct()
            .ToArrayAsync();
    }

    public async Task<int[]> GetRelatedImages(IEnumerable<int> ids, ImageType? typeId = null)
    {
        var donors = await GetRelatedDonors(ids);

        return await _donorsRepository.GetRelatedImages(donors, typeId);
    }

    public async Task<int[]> GetRelatedSpecimens(IEnumerable<int> ids, SpecimenType? typeId = null)
    {
        var donors = await GetRelatedDonors(ids);

        return await _donorsRepository.GetRelatedSpecimens(donors, typeId);
    }

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Images.Analysis.Enums.AnalysisType> typeIds = null)
    {
        var donors = await GetRelatedDonors(ids);

        return await _donorsRepository.GetRelatedSamples(donors, typeIds);
    }

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Specimens.Analysis.Enums.AnalysisType> typeIds = null)
    {
        var donors = await GetRelatedDonors(ids);

        return await _donorsRepository.GetRelatedSamples(donors, typeIds);
    }

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Genome.Analysis.Enums.AnalysisType> typeIds = null)
    {
        var donors = await GetRelatedDonors(ids);

        return await _donorsRepository.GetRelatedSamples(donors, typeIds);
    }

    public async Task<int[]> GetRelatedGenes(IEnumerable<int> ids)
    {
        var donors = await GetRelatedDonors(ids);

        return await _donorsRepository.GetRelatedGenes(donors);
    }

    public async Task<int[]> GetRelatedVariants<TV>(IEnumerable<int> ids)
        where TV : Variant
    {
        var donors = await GetRelatedDonors(ids);

        return await _donorsRepository.GetRelatedVariants<TV>(donors);
    }
}
