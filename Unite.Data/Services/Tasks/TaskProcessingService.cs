using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Services.Tasks;

public class TasksProcessingService
{
    private readonly DomainDbContext _dbContext;


    public TasksProcessingService(DomainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Process indexing tasks in batches running handler for each batch
    /// </summary>
    /// <param name="type">Indexing task type</param>
    /// <param name="bucketSize">Bucket size</param>
    /// <param name="handler">Processing handler</param>
    public void Process(IndexingTaskType type, int bucketSize, Action<Unite.Data.Entities.Tasks.Task[]> handler)
    {
        while (true)
        {
            var tasks = _dbContext.Tasks
                .Where(task => task.IndexingTypeId == type)
                .OrderByDescending(task => task.Date)
                .Take(bucketSize)
                .ToArray();

            if (tasks != null && tasks.Any())
            {
                handler.Invoke(tasks);

                _dbContext.Tasks.RemoveRange(tasks);
                _dbContext.SaveChanges();
            }
            else
            {
                return;
            }
        }
    }

    /// <summary>
    /// Process annotation tasks in batches running handler for each batch
    /// </summary>
    /// <param name="type">Annotation task type</param>
    /// <param name="bucketSize">Bucket size</param>
    /// <param name="handler">Processing handler</param>
    public void Process(AnnotationTaskType type, int bucketSize, Action<Unite.Data.Entities.Tasks.Task[]> handler)
    {
        while (true)
        {
            var tasks = _dbContext.Tasks
                .Where(task => task.AnnotationTypeId == type)
                .OrderByDescending(task => task.Date)
                .Take(bucketSize)
                .ToArray();

            if (tasks != null && tasks.Any())
            {
                handler.Invoke(tasks);

                _dbContext.Tasks.RemoveRange(tasks);
                _dbContext.SaveChanges();
            }
            else
            {
                return;
            }
        }
    }
}
