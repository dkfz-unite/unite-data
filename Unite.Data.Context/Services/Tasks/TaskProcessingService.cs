using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Services.Tasks;

public class TasksProcessingService
{
    private readonly IDbContextFactory<DomainDbContext> _dbContextFactory;


    public TasksProcessingService(IDbContextFactory<DomainDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }


    /// <summary>
    /// Verifies if worker of given type is active.
    /// </summary>
    /// <param name="type">Worker type.</param>
    /// <returns>True, if worker is active, False otherwise.</returns>
    public bool IsActive(WorkerType type)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return dbContext.Set<Entities.Tasks.Worker>()
            .AsNoTracking()
            .Where(worker => worker.TypeId == type)
            .Where(worker => worker.Active)
            .Any();
    }

    /// <summary>
    /// Verifies if there are any tasks for given worker type.
    /// </summary>
    /// <param name="type">Worker type.</param>
    /// <returns>True, if there are tasks for given worker type, False otherwise.</returns>
    public bool HasTasks(WorkerType type)
    {
        Expression<Func<Entities.Tasks.Task, bool>> predicate = 
            type == WorkerType.Submission ? task => task.SubmissionTypeId != null :
            type == WorkerType.Annotation ? task => task.AnnotationTypeId != null :
            type == WorkerType.Indexing ? task => task.IndexingTypeId != null :
            task => false;
                        
        using var dbContext = _dbContextFactory.CreateDbContext();

        return dbContext.Set<Entities.Tasks.Task>()
            .AsNoTracking()
            .Where(predicate)
            .Any();
    }

    /// <summary>
    /// Process submission tasks in batches running handler for each batch.
    /// </summary>
    /// <param name="type">Submission task type.</param>
    /// <param name="bucketSize">Bucket size.</param>
    /// <param name="handler">Processing handler.</param>
    public void Process(SubmissionTaskType type, int bucketSize, Func<Entities.Tasks.Task[], bool> handler)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        while (true)
        {
            var tasks = dbContext.Tasks
                .Where(task => task.SubmissionTypeId == type)
                .OrderBy(task => task.Target)
                .Take(bucketSize)
                .ToArray();

            if (tasks != null && tasks.Any())
            {
                var success = handler.Invoke(tasks);

                if (success)
                {
                    dbContext.Tasks.RemoveRange(tasks);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                return;
            }
        }
    }

    /// <summary>
    /// Process annotation tasks in batches running handler for each batch.
    /// </summary>
    /// <param name="type">Annotation task type.</param>
    /// <param name="bucketSize">Bucket size.</param>
    /// <param name="handler">Processing handler.</param>
    public void Process(AnnotationTaskType type, int bucketSize, Func<Entities.Tasks.Task[], bool> handler)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        while (true)
        {
            var tasks = dbContext.Tasks
                .Where(task => task.AnnotationTypeId == type)
                .OrderBy(task => task.Date)
                .ThenBy(task => task.Target)
                .Take(bucketSize)
                .ToArray();

            if (tasks != null && tasks.Any())
            {
                var success = handler.Invoke(tasks);

                if (success)
                {
                    dbContext.Tasks.RemoveRange(tasks);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                return;
            }
        }
    }

    /// <summary>
    /// Process indexing tasks in batches running handler for each batch.
    /// </summary>
    /// <param name="type">Indexing task type.</param>
    /// <param name="bucketSize">Bucket size.</param>
    /// <param name="handler">Processing handler.</param>
    public void Process(IndexingTaskType type, int bucketSize, Func<Entities.Tasks.Task[], bool> handler)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        while (true)
        {
            var tasks = dbContext.Tasks
                .Where(task => task.IndexingTypeId == type)
                .OrderBy(task => task.Target)
                .Take(bucketSize)
                .ToArray();

            if (tasks != null && tasks.Any())
            {
                var success = handler.Invoke(tasks);

                if (success)
                {
                    dbContext.Tasks.RemoveRange(tasks);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                return;
            }
        }
    }
}
