using System.Linq.Expressions;
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
    /// Create indexing tasks
    /// </summary>
    /// <typeparam name="T">Key type</typeparam>
    /// <param name="type">Indexing task type</param>
    /// <param name="keys">Collection of keys</param>
    protected void CreateTasks<T>(
        IndexingTaskType type,
        IEnumerable<T> keys)
    {
        var tasks = new List<Entities.Tasks.Task>();

        foreach (var key in keys)
        {
            var exists = _dbContext.Set<Entities.Tasks.Task>().Any(task =>
                task.IndexingTypeId == type &&
                task.Target == key.ToString()
            );

            if (!exists)
            {
                tasks.Add(new Entities.Tasks.Task
                {
                    IndexingTypeId = type,
                    Target = key.ToString(),
                    Date = DateTime.UtcNow
                });
            }
        }

        _dbContext.AddRange(tasks);
        _dbContext.SaveChanges();
    }

    /// <summary>
    /// Create annotation tasks
    /// </summary>
    /// <typeparam name="T">Key type</typeparam>
    /// <param name="type">Annotation task type</param>
    /// <param name="keys">Collection of keys</param>
    protected void CreateTasks<T>(
        AnnotationTaskType type,
        IEnumerable<T> keys)
    {
        var tasks = new List<Entities.Tasks.Task>();

        foreach (var key in keys)
        {
            var exists = _dbContext.Set<Entities.Tasks.Task>().Any(task =>
                task.AnnotationTypeId == type &&
                task.Target == key.ToString()
            );

            if (!exists)
            {
                tasks.Add(new Entities.Tasks.Task
                {
                    AnnotationTypeId = type,
                    Target = key.ToString(),
                    Date = DateTime.UtcNow
                });
            }
        }

        _dbContext.AddRange(tasks);
        _dbContext.SaveChanges();
    }

    /// <summary>
    /// Iterate entities of the database in batches running handler for each batch
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <typeparam name="TKey">Entity key type</typeparam>
    /// <param name="condition">Entity selection condition</param>
    /// <param name="selector">Entity selector</param>
    /// <param name="handler">Action handler</param>
    protected void IterateEntities<T, TKey>(
        Expression<Func<T, bool>> condition,
        Expression<Func<T, TKey>> selector,
        Action<IEnumerable<TKey>> handler)
        where T : class
    {
        var position = 0;

        var entities = Enumerable.Empty<TKey>();

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
        while (entities.Count() == BucketSize);
    }
}
