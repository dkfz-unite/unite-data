using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Services.Tasks;

public abstract class AnnotationTaskService<T, TKey> : TaskService where T : class
{
    protected AnnotationTaskService(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }


    /// <summary>
    /// Modifies activation status of worker.
    /// </summary>
    public void ChangeStatus(bool active)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        var worker = dbContext.Set<Worker>()
            .AsNoTracking()
            .First(worker => worker.TypeId == WorkerType.Annotation);

        worker.Active = active;

        dbContext.Update(worker);
        dbContext.SaveChanges();
    }

    /// <summary>
    /// Creates only target type annotation tasks for all existing entities of target type.
    /// </summary>
    public abstract void CreateTasks();

    /// <summary>
    /// Creates only target type annotation tasks for all entities of target type with given identifiers.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    public abstract void CreateTasks(IEnumerable<TKey> keys);

    /// <summary>
    /// Populates all types of annotation tasks for entities of target type with given identifiers.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    public abstract void PopulateTasks(IEnumerable<TKey> keys);
}
