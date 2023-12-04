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
    /// Verifies whether there are submission tasks in the database.
    /// </summary>
    /// <returns>True, if submission tasks exist in the database, False otherwise.</returns>
    public bool HasSubmissionTasks()
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return dbContext.Set<Entities.Tasks.Task>()
            .Any(task => task.SubmissionTypeId != null);
    }

    /// <summary>
    /// Verifies whether there are annotation tasks in the database.
    /// </summary>
    /// <returns>True, if annotation tasks exist in the database, False otherwise.</returns>
    public bool HasAnnotationTasks()
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return dbContext.Set<Entities.Tasks.Task>()
            .Any(task => task.AnnotationTypeId != null);
    }

    /// <summary>
    /// Verifies whether there are indexing tasks in the database.
    /// </summary>
    /// <returns>True, if indexing tasks exist in the database, False otherwise.</returns>
    public bool HasIndexingTasks()
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return dbContext.Set<Entities.Tasks.Task>()
            .Any(task => task.IndexingTypeId != null);
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
