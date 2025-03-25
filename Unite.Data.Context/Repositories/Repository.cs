using Microsoft.EntityFrameworkCore;

namespace Unite.Data.Context.Repositories;

public abstract class Repository
{
    protected readonly IDbContextFactory<DomainDbContext> _dbContextFactory;


    public Repository(IDbContextFactory<DomainDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }


    protected async Task<int[]> GetDonorRelatedProjects(IEnumerable<int> ids)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<Entities.Donors.ProjectDonor>()
            .AsNoTracking()
            .Where(projectDonor => ids.Contains(projectDonor.DonorId))
            .Select(projectDonor => projectDonor.ProjectId)
            .Distinct()
            .ToArrayAsync();
    }
}
