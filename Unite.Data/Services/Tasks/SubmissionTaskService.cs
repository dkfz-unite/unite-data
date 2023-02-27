using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Services.Tasks;

public class SubmissionTaskService : TaskService
{
    protected override int BucketSize => 1;


    public SubmissionTaskService(DomainDbContext dbContext) : base(dbContext)
    {
    }

    public void CreateTask(string key, SubmissionTaskType type)
    {
        CreateTask<object>(key, SubmissionTaskType.CNV, null);
    }

    public void CreateTask<TData>(string key, SubmissionTaskType type, TData data = null) where TData : class
    {
        CreateTask(key, type, data);
    }
}
