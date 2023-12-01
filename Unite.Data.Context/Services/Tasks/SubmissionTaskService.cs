using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Services.Tasks;

public class SubmissionTaskService : TaskService
{
    protected override int BucketSize => 1;


    public SubmissionTaskService(DomainDbContext dbContext) : base(dbContext)
    {
    }

    public void CreateTask(SubmissionTaskType type, string key)
    {
        CreateTask<string, object>(type, key, null);
    }

    public void CreateTask<TData>(SubmissionTaskType type, string key, TData data = null) where TData : class
    {
        CreateTask<string, TData>(type, key, data);
    }
}
