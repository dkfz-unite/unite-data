using Microsoft.EntityFrameworkCore;

namespace Unite.Data.Context.Repositories;

public class DataUserRepository: Repository
{
    public DataUserRepository(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }
    
    public async Task<int[]> GetRelatedProjects(IEnumerable<int> ids)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<Entities.Donors.ProjectUser>()
            .AsNoTracking()
            .Where(projectUser => ids.Contains(projectUser.UserId))
            .Select(projectUser => projectUser.ProjectId)
            .Distinct()
            .ToArrayAsync();
    }
}