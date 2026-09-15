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

    public async Task<DataUser> LoadOrCreate(int userId)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var dataUser = await dbContext.DataUsers
            .FirstOrDefaultAsync(du => du.UserId == userId);

        if (dataUser is null)
        {
            dataUser = new DataUser
            {
                UserId = userId
            };
            dbContext.DataUsers.Add(dataUser);
            await dbContext.SaveChangesAsync();
        }

        return dataUser;
    }
}