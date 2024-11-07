using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Essentials.Extensions;

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
    /// Process submission tasks in batches running handler for each batch if worker is active.
    /// </summary>
    /// <param name="type">Submission task type.</param>
    /// <param name="statusTypeId">Submission task status type.</param>
    /// <param name="bucketSize">Bucket size.</param>
    /// <param name="handler">Processing handler.</param>
    public void Process(SubmissionTaskType type, int bucketSize, Func<Entities.Tasks.Task[], bool> handler)
    {
        Process(WorkerType.Submission, task => task.SubmissionTypeId == type && task.StatusTypeId == TaskStatusType.Prepared, bucketSize, handler);
    }

    /// <summary>
    /// Process annotation tasks in batches running handler for each batch if worker is active.
    /// </summary>
    /// <param name="type">Annotation task type.</param>
    /// <param name="bucketSize">Bucket size.</param>
    /// <param name="handler">Processing handler.</param>
    public void Process(AnnotationTaskType type, int bucketSize, Func<Entities.Tasks.Task[], bool> handler)
    {
        Process(WorkerType.Annotation, task => task.AnnotationTypeId == type, bucketSize, handler);
    }

    /// <summary>
    /// Process indexing tasks in batches running handler for each batch if worker is active.
    /// </summary>
    /// <param name="type">Indexing task type.</param>
    /// <param name="bucketSize">Bucket size.</param>
    /// <param name="handler">Processing handler.</param>
    public void Process(IndexingTaskType type, int bucketSize, Func<Entities.Tasks.Task[], bool> handler)
    {
        Process(WorkerType.Indexing, task => task.IndexingTypeId == type, bucketSize, handler);
    }

    /// <summary>
    /// Process submission tasks asynchronously in batches running handler for each batch if worker is active.
    /// </summary>
    /// <param name="type">Submission task type.</param>
    /// <param name="bucketSize">Bucket size.</param>
    /// <param name="handler">Processing handler.</param>
    public async Task Process(SubmissionTaskType type, int bucketSize, Func<Entities.Tasks.Task[], Task<bool>> handler)
    {
        await Process(WorkerType.Submission, task => task.SubmissionTypeId == type, bucketSize, handler);
    }

    /// <summary>
    /// Process annotation tasks asynchronously in batches running handler for each batch if worker is active.
    /// </summary>
    /// <param name="type">Annotation task type.</param>
    /// <param name="bucketSize">Bucket size.</param>
    /// <param name="handler">Processing handler.</param>
    public async Task Process(AnnotationTaskType type, int bucketSize, Func<Entities.Tasks.Task[], Task<bool>> handler)
    {
        await Process(WorkerType.Annotation, task => task.AnnotationTypeId == type, bucketSize, handler);
    }

    /// <summary>
    /// Process indexing tasks asynchronously in batches running handler for each batch if worker is active.
    /// </summary>
    /// <param name="type">Indexing task type.</param>
    /// <param name="bucketSize">Bucket size.</param>
    /// <param name="handler">Processing handler.</param> 
    public async Task Process(IndexingTaskType type, int bucketSize, Func<Entities.Tasks.Task[], Task<bool>> handler)
    {
        await Process(WorkerType.Indexing, task => task.IndexingTypeId == type, bucketSize, handler);
    }


    private void Process(WorkerType type, Expression<Func<Entities.Tasks.Task, bool>> filter, int bucketSize, Func<Entities.Tasks.Task[], bool> handler)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        if (!IsActive(type))
        {
            return;
        }

        while (true)
        {
            var tasks = dbContext.Set<Entities.Tasks.Task>()
                .Where(filter)
                .OrderByDescending(task => task.Date)
                .Take(bucketSize)
                .ToArray();

            if (tasks.IsNotEmpty())
            {
                var success = handler.Invoke(tasks);
                var active = IsActive(type);

                if (success && active)
                {
                    dbContext.RemoveRange(tasks);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                return;
            }
        }
    }

    private async Task Process(WorkerType type, Expression<Func<Entities.Tasks.Task, bool>> filter, int bucketSize, Func<Entities.Tasks.Task[], Task<bool>> handler)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        if (!IsActive(type))
        {
            return;
        }

        while (true)
        {
            var tasks = await dbContext.Set<Entities.Tasks.Task>()
                .Where(filter)
                .OrderByDescending(task => task.Date)
                .Take(bucketSize)
                .ToArrayAsync();

            if (tasks.IsNotEmpty())
            {
                var success = await handler.Invoke(tasks);
                var active = IsActive(type);

                if (success && active)
                {
                    dbContext.RemoveRange(tasks);
                    await dbContext.SaveChangesAsync();
                }
            }
            else
            {
                return;
            }
        }
    }
}
