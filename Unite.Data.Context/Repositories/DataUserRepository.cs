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
    
    public async Task<List<DataUser>> Load(int[] userIds)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
    
        return await dbContext.DataUsers
            .Where(du => userIds.Contains(du.UserId))
            .ToListAsync();
    }

    public async Task<List<DataUser>> LoadOrCreate(int[] userIds)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var distinctUserIds = userIds.Distinct().ToArray();

        var existingDataUsers = await dbContext.DataUsers
            .Where(du => distinctUserIds.Contains(du.UserId))
            .ToListAsync();

        var existingUserIds = existingDataUsers.Select(du => du.UserId).ToHashSet();

        var newDataUsers = distinctUserIds
            .Where(userId => !existingUserIds.Contains(userId))
            .Select(userId => new DataUser { UserId = userId })
            .ToList();

        if (newDataUsers.Count > 0)
        {
            dbContext.DataUsers.AddRange(newDataUsers);
            await dbContext.SaveChangesAsync();
        }

        return existingDataUsers.Concat(newDataUsers).ToList();
    }

    public async Task Delete(int[] dataUserIds)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var dataUsers = await dbContext.DataUsers
            .Where(du => dataUserIds.Contains(du.Id))
            .ToListAsync();

        if (dataUsers.Count > 0)
        {
            dbContext.DataUsers.RemoveRange(dataUsers);
            await dbContext.SaveChangesAsync();
        }
    }
}