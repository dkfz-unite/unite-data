﻿using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Services.Tasks;

public class TasksProcessingService
{
    private readonly DomainDbContext _dbContext;


    public TasksProcessingService(DomainDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Verifies whether there are indexing tasks in the database.
    /// </summary>
    /// <returns>True, if indexing tasks exist in the database, False otherwise.</returns>
    public bool HasIndexingTasks()
    {
        return _dbContext.Set<Entities.Tasks.Task>()
            .Any(task => task.IndexingTypeId != null);
    }

    /// <summary>
    /// Verifies whether there are annotation tasks in the database.
    /// </summary>
    /// <returns>True, if annotation tasks exist in the database, False otherwise.</returns>
    public bool HasAnnotationTasks()
    {
        return _dbContext.Set<Entities.Tasks.Task>()
            .Any(task => task.AnnotationTypeId != null);
    }

    /// <summary>
    /// Process indexing tasks in batches running handler for each batch.
    /// </summary>
    /// <param name="type">Indexing task type.</param>
    /// <param name="bucketSize">Bucket size.</param>
    /// <param name="handler">Processing handler.</param>
    public void Process(IndexingTaskType type, int bucketSize, Action<Entities.Tasks.Task[]> handler)
    {
        while (true)
        {
            var tasks = _dbContext.Tasks
                .Where(task => task.IndexingTypeId == type)
                .OrderBy(task => task.Target)
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
    /// Process annotation tasks in batches running handler for each batch.
    /// </summary>
    /// <param name="type">Annotation task type.</param>
    /// <param name="bucketSize">Bucket size.</param>
    /// <param name="handler">Processing handler.</param>
    public void Process(AnnotationTaskType type, int bucketSize, Action<Entities.Tasks.Task[]> handler)
    {
        while (true)
        {
            var tasks = _dbContext.Tasks
                .Where(task => task.AnnotationTypeId == type)
                .OrderBy(task => task.Date)
                .ThenBy(task => task.Target)
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
