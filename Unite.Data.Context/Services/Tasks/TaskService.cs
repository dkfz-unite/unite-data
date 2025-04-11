using System.Linq.Expressions;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Services.Tasks;

public abstract class TaskService
{
    protected readonly IDbContextFactory<DomainDbContext> _dbContextFactory;

    protected abstract int BucketSize { get; }


    protected TaskService(IDbContextFactory<DomainDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }


    /// <summary>
    /// Get tasks by id.
    /// </summary>
    /// <param name="id">Task id.</param>
    /// <returns>Task is was found.</returns>
    public Entities.Tasks.Task GetTask(long id)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var task = dbContext.Set<Entities.Tasks.Task>()
            .AsNoTracking()
            .FirstOrDefault(task => task.Id == id);

        return task;
    }

    /// <summary>
    /// Creates submission task.
    /// </summary>
    /// <typeparam name="TKey">Key type.</typeparam>
    /// <typeparam name="TData">Data type.</typeparam>
    /// <param name="type">Indexing task type.</param>
    /// <param name="key">Key.</param>
    /// <param name="data">Initial data.</param>
    /// <param name="status">Initial status.</param>
    /// <returns>Identifier of created or existing task.</returns>
    protected long CreateTask<TKey, TData>(
        SubmissionTaskType type,
        TKey key,
        TData data = null,
        TaskStatusType? status = null)
        where TData : class
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var task = dbContext.Set<Entities.Tasks.Task>().FirstOrDefault(task => task.SubmissionTypeId == type && task.Target == key.ToString());

        if (task == null)
        {
            task = new Entities.Tasks.Task
            {
                SubmissionTypeId = type,
                Target = key.ToString(),
                Data = data != null ? JsonSerializer.Serialize(data) : null,
                StatusTypeId = status,
                Date = DateTime.UtcNow
            };

            dbContext.Add(task);
            dbContext.SaveChanges();
        }

        return task.Id;
    }

    /// <summary>
    /// Creates indexing task.
    /// </summary>
    /// <typeparam name="TKey">Key type.</typeparam>
    /// <typeparam name="TData">Data type.</typeparam>
    /// <param name="type">Indexing task type.</param>
    /// <param name="key">Key.</param>
    /// <param name="data">Initial data.</param>
    /// <param name="status">Initial status.</param>
    /// <returns>Identifier of created or existing task.</returns>
    protected long CreateTask<TKey, TData>(
        IndexingTaskType type,
        TKey key,
        TData data = null,
        TaskStatusType? status = null)
        where TData : class
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var task = dbContext.Set<Entities.Tasks.Task>().FirstOrDefault(task => task.IndexingTypeId == type && task.Target == key.ToString());

        if (task == null)
        {
            task = new Entities.Tasks.Task
            {
                IndexingTypeId = type,
                Target = key.ToString(),
                Data = data != null ? JsonSerializer.Serialize(data) : null,
                StatusTypeId = status,
                Date = DateTime.UtcNow
            };

            dbContext.Add(task);
            dbContext.SaveChanges();
        }

        return task.Id;
    }

    /// <summary>
    /// Creates annotation task.
    /// </summary>
    /// <typeparam name="TKey">Key type.</typeparam>
    /// <typeparam name="TData">Data type.</typeparam>
    /// <param name="type">Indexing task type.</param>
    /// <param name="key">Key.</param>
    /// <param name="data">Initial data.</param>
    /// <param name="status">Initial status.</param>
    /// <returns>Identifier of created or existing task.</returns>
    protected long CreateTask<TKey, TData>(
        AnnotationTaskType type,
        TKey key,
        TData data = null,
        TaskStatusType? status = null)
        where TData : class
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var task = dbContext.Set<Entities.Tasks.Task>().FirstOrDefault(task => task.AnnotationTypeId == type && task.Target == key.ToString());

        if (task == null)
        {
            task = new Entities.Tasks.Task
            {
                AnnotationTypeId = type,
                Target = key.ToString(),
                Data = data != null ? JsonSerializer.Serialize(data) : null,
                StatusTypeId = status,
                Date = DateTime.UtcNow
            };

            dbContext.Add(task);
            dbContext.SaveChanges();
        }

        return task.Id;
    }

    /// <summary>
    /// Create indexing tasks.
    /// </summary>
    /// <typeparam name="T">Key type.</typeparam>
    /// <param name="type">Indexing task type.</param>
    /// <param name="keys">Collection of keys.</param>
    protected void CreateTasks<T>(
        IndexingTaskType type,
        IEnumerable<T> keys)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var allTargets = keys.Select(key => key.ToString()).ToArray();

        var existingTargets = dbContext.Set<Entities.Tasks.Task>()
            .Where(task => task.IndexingTypeId == type && allTargets.Contains(task.Target))
            .Select(task => task.Target)
            .ToArray();

        var newTargets = allTargets.Except(existingTargets).ToArray();

        if (newTargets.Any())
        {
            var tasks = newTargets.Select(target => new Entities.Tasks.Task
            {
                IndexingTypeId = type,
                Target = target,
                Date = DateTime.UtcNow

            }).ToArray();

            dbContext.AddRange(tasks);
            dbContext.SaveChanges();
        }
    }

    /// <summary>
    /// Create annotation tasks.
    /// </summary>
    /// <typeparam name="T">Key type.</typeparam>
    /// <param name="type">Annotation task type.</param>
    /// <param name="keys">Collection of keys.</param>
    protected void CreateTasks<T>(
        AnnotationTaskType type,
        IEnumerable<T> keys)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var allTargets = keys.Select(key => key.ToString()).ToArray();

        var existingTargets = dbContext.Set<Entities.Tasks.Task>()
            .Where(task => task.AnnotationTypeId == type && allTargets.Contains(task.Target))
            .Select(task => task.Target)
            .ToArray();

        var newTargets = allTargets.Except(existingTargets).ToArray();

        if (newTargets.Any())
        {
            var tasks = newTargets.Select(target => new Entities.Tasks.Task
            {
                AnnotationTypeId = type,
                Target = target,
                Date = DateTime.UtcNow

            }).ToArray();

            dbContext.AddRange(tasks);
            dbContext.SaveChanges();
        }
    }

    /// <summary>
    /// Create submission tasks.
    /// </summary>
    /// <typeparam name="T">Key type.</typeparam>
    /// <param name="type">Submission task type.</param>
    /// <param name="keys">Collection of keys.</param>
    protected void CreateTasks<T>(
        SubmissionTaskType type,
        IEnumerable<T> keys)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var allTargets = keys.Select(key => key.ToString()).ToArray();

        var existingTargets = dbContext.Set<Entities.Tasks.Task>()
            .Where(task => task.SubmissionTypeId == type && allTargets.Contains(task.Target))
            .Select(task => task.Target)
            .ToArray();

        var newTargets = allTargets.Except(existingTargets).ToArray();

        if (newTargets.Any())
        {
            var tasks = newTargets.Select(target => new Entities.Tasks.Task
            {
                SubmissionTypeId = type,
                Target = target,
                Date = DateTime.UtcNow

            }).ToArray();

            dbContext.AddRange(tasks);
            dbContext.SaveChanges();
        }
    }

    /// <summary>
    /// Iterate entities of the database in batches running handler for each batch.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <typeparam name="TKey">Entity key type</typeparam>
    /// <param name="condition">Entity selection condition</param>
    /// <param name="selector">Entity selector</param>
    /// <param name="handler">Action handler</param>
    protected void IterateEntities<T, TKey>(
        Expression<Func<T, bool>> condition,
        Expression<Func<T, TKey>> selector,
        Action<TKey[]> handler)
        where T : class
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var position = 0;

        var entities = Array.Empty<TKey>();

        do
        {
            entities = dbContext.Set<T>()
                .Where(condition)
                .Skip(position)
                .Take(BucketSize)
                .Select(selector)
                .ToArray();

            handler.Invoke(entities);

            position += entities.Length;

        }
        while (entities.Length == BucketSize);
    }
}
