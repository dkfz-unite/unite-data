using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities;

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
    
    public async Task<List<DataUser>> LoadAll()
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
    
        return await dbContext.DataUsers.ToListAsync();
    }
    
    public async Task<List<DataUser>> Load(int[] userIds)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
    
        return await dbContext.DataUsers
            .Where(du => userIds.Contains(du.UserId))
            .ToListAsync();
    }
}