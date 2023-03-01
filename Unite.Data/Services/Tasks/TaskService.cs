using System.Linq.Expressions;
using System.Text.Json;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Services.Tasks;

public abstract class TaskService
{
    protected readonly DomainDbContext _dbContext;

    protected abstract int BucketSize { get; }


    protected TaskService(DomainDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    /// <summary>
    /// Creates indexing task.
    /// </summary>
    /// <typeparam name="TKey">Key type.</typeparam>
    /// <typeparam name="TData">Data type.</typeparam>
    /// <param name="type">Indexing task type.</param>
    /// <param name="key">Key.</param>
    /// <param name="data">Data.</param>
    protected void CreateTask<TKey, TData>(
        IndexingTaskType type,
        TKey key,
        TData data = null)
        where TData : class
    {
        var exists = _dbContext.Set<Entities.Tasks.Task>().Any(task => task.IndexingTypeId == type && task.Target == key.ToString());

        if (!exists)
        {
            var task = new Entities.Tasks.Task
            {
                IndexingTypeId = type,
                Target = key.ToString(),
                Data = data != null ? JsonSerializer.Serialize(data) : null,
                Date = DateTime.UtcNow
            };

            _dbContext.Add(task);
            _dbContext.SaveChanges();
        }
    }

    /// <summary>
    /// Creates annotation task.
    /// </summary>
    /// <typeparam name="TKey">Key type.</typeparam>
    /// <typeparam name="TData">Data type.</typeparam>
    /// <param name="type">Indexing task type.</param>
    /// <param name="key">Key.</param>
    /// <param name="data">Data.</param>
    protected void CreateTask<TKey, TData>(
        AnnotationTaskType type,
        TKey key,
        TData data = null)
        where TData : class
    {
        var exists = _dbContext.Set<Entities.Tasks.Task>().Any(task => task.AnnotationTypeId == type && task.Target == key.ToString());

        if (!exists)
        {
            var task = new Entities.Tasks.Task
            {
                AnnotationTypeId = type,
                Target = key.ToString(),
                Data = data != null ? JsonSerializer.Serialize(data) : null,
                Date = DateTime.UtcNow
            };

            _dbContext.Add(task);
            _dbContext.SaveChanges();
        }
    }

    /// <summary>
    /// Creates submission task.
    /// </summary>
    /// <typeparam name="TKey">Key type.</typeparam>
    /// <typeparam name="TData">Data type.</typeparam>
    /// <param name="type">Indexing task type.</param>
    /// <param name="key">Key.</param>
    /// <param name="data">Data.</param>
    protected void CreateTask<TKey, TData>(
        SubmissionTaskType type,
        TKey key,
        TData data = null)
        where TData : class
    {
        var exists = _dbContext.Set<Entities.Tasks.Task>().Any(task => task.SubmissionTypeId == type && task.Target == key.ToString());

        if (!exists)
        {
            var task = new Entities.Tasks.Task
            {
                SubmissionTypeId = type,
                Target = key.ToString(),
                Data = data != null ? JsonSerializer.Serialize(data) : null,
                Date = DateTime.UtcNow
            };

            _dbContext.Add(task);
            _dbContext.SaveChanges();
        }
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
        var allTargets = keys.Select(key => key.ToString()).ToArray();

        var existingTargets = _dbContext.Set<Entities.Tasks.Task>()
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

            _dbContext.AddRange(tasks);
            _dbContext.SaveChanges();
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
        var allTargets = keys.Select(key => key.ToString()).ToArray();

        var existingTargets = _dbContext.Set<Entities.Tasks.Task>()
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

            _dbContext.AddRange(tasks);
            _dbContext.SaveChanges();
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
        var allTargets = keys.Select(key => key.ToString()).ToArray();

        var existingTargets = _dbContext.Set<Entities.Tasks.Task>()
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

            _dbContext.AddRange(tasks);
            _dbContext.SaveChanges();
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
        var position = 0;

        var entities = Array.Empty<TKey>();

        do
        {
            entities = _dbContext.Set<T>()
                .Where(condition)
                .Skip(position)
                .Take(BucketSize)
                .Select(selector)
                .ToArray();

            handler.Invoke(entities);

            position += entities.Count();

        }
        while (entities.Length == BucketSize);
    }
}
