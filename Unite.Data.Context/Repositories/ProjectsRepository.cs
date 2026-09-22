using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Omics.Analysis.Dna;
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
    
    public async Task<int[]> GetRelatedUsers(IEnumerable<int> ids)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<Entities.Donors.ProjectUser>()
            .AsNoTracking()
            .Where(projectUser => ids.Contains(projectUser.ProjectId))
            .Select(projectUser => projectUser.UserId)
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

    public async Task<int[]> GetRelatedSamples(IEnumerable<int> ids, IEnumerable<Entities.Omics.Analysis.Enums.AnalysisType> typeIds = null)
    {
        var donors = await GetRelatedDonors(ids);

        return await _donorsRepository.GetRelatedSamples(donors, typeIds);
    }

    public async Task<int[]> GetRelatedGenes(IEnumerable<int> ids)
    {
        var donors = await GetRelatedDonors(ids);

        return await _donorsRepository.GetRelatedGenes(donors);
    }

    public async Task<int[]> GetRelatedProteins(IEnumerable<int> ids)
    {
        var donors = await GetRelatedDonors(ids);

        return await _donorsRepository.GetRelatedProteins(donors);
    }

    public async Task<int[]> GetRelatedVariants<TV>(IEnumerable<int> ids)
        where TV : Variant
    {
        var donors = await GetRelatedDonors(ids);

        return await _donorsRepository.GetRelatedVariants<TV>(donors);
    }
    
    public async Task<List<ProjectUser>> AssignToProject(int[] dataUserIds, int projectId)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var distinctUserIds = dataUserIds.Distinct().ToArray();

        var existingProjectUsers = await dbContext.Set<Entities.Donors.ProjectUser>()
            .Where(x => x.ProjectId == projectId && distinctUserIds.Contains(x.UserId))
            .ToListAsync();

        var existingUserIds = existingProjectUsers.Select(x => x.UserId).ToHashSet();

        var newProjectUsers = distinctUserIds
            .Where(userId => !existingUserIds.Contains(userId))
            .Select(userId => new ProjectUser { ProjectId = projectId, UserId = userId })
            .ToList();

        if (newProjectUsers.Count > 0)
        {
            dbContext.Set<Entities.Donors.ProjectUser>().AddRange(newProjectUsers);
            await dbContext.SaveChangesAsync();
        }

        return existingProjectUsers.Concat(newProjectUsers).ToList();
    }
    
    public async Task RemoveFromProject(int[] dataUserIds, int projectId)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var projectUsers = await dbContext.Set<Entities.Donors.ProjectUser>()
            .Where(x => x.ProjectId == projectId && dataUserIds.Contains(x.UserId))
            .ToListAsync();

        if (projectUsers.Count > 0)
        {
            dbContext.Set<Entities.Donors.ProjectUser>().RemoveRange(projectUsers);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<Project> Load(int projectId)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();

        return await dbContext.Projects.FirstOrDefaultAsync(x => x.Id == projectId);
    }
}
