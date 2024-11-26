using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Services.Tasks;

public class SubmissionTaskService : TaskService
{
    protected override int BucketSize => 1;


    public SubmissionTaskService(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }


    /// <summary>
    /// Modifies activation status of worker.
    /// </summary>
    public void ChangeStatus(bool active)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var worker = dbContext.Set<Worker>()
            .AsNoTracking()
            .First(worker => worker.TypeId == WorkerType.Submission);

        worker.Active = active;

        dbContext.Update(worker);
        dbContext.SaveChanges();
    }

    public long CreateTask(SubmissionTaskType type, string key, TaskStatusType status)
    {
       return CreateTask<string, object>(type, key, null, status);
    }

    public long CreateTask<TData>(SubmissionTaskType type, string key, TData data = null, TaskStatusType? status = null) where TData : class
    {
        return CreateTask<string, TData>(type, key, data, status);
    }
}
