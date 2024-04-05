using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Services.Tasks;

public abstract class IndexingTaskService<T, TKey> : TaskService where T : class
{
    protected IndexingTaskService(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
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
            .First(worker => worker.TypeId == WorkerType.Indexing);

        worker.Active = active;

        dbContext.Update(worker);
        dbContext.SaveChanges();
    }

    /// <summary>
    /// Creates only target type indexing tasks for all existing entities of target type.
    /// </summary>
    public abstract void CreateTasks();

    /// <summary>
    /// Creates only target type indexing tasks for all entities of target type with given identifiers.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    public abstract void CreateTasks(IEnumerable<TKey> keys);

    /// <summary>
    /// Populates all types of indexing tasks for entities of target type with given identifiers.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    public abstract void PopulateTasks(IEnumerable<TKey> keys);


    /// <summary>
    /// Loads projects related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    protected abstract IEnumerable<int> LoadRelatedProjects(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads donors related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    /// <returns>Collection of dependint donors identifiers.</returns>
    protected abstract IEnumerable<int> LoadRelatedDonors(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads images related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    /// <returns>Collection of dependint images identifiers.</returns>
    protected abstract IEnumerable<int> LoadRelatedImages(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads specimens related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    /// <returns>Collection of dependint specimens identifiers.</returns>
    protected abstract IEnumerable<int> LoadRelatedSpecimens(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads genes related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    /// <returns>Collection of dependint genes identifiers.</returns>
    protected abstract IEnumerable<int> LoadRelatedGenes(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads SSMs related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    /// <returns>Collection of dependint SSMs identifiers.</returns>
    protected abstract IEnumerable<long> LoadRelatedSsms(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads CNVs related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    /// <returns>Collection of dependint CNVs identifiers.</returns>
    protected abstract IEnumerable<long> LoadRelatedCnvs(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads SVs related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    /// <returns>Collection of dependint SVs identifiers.</returns>
    protected abstract IEnumerable<long> LoadRelatedSvs(IEnumerable<TKey> keys);


    /// <summary>
    /// Creates projects indexing tasks for all projects depeding on entities of given type with given keys.
    /// </summary>
    /// <param name="keys"></param>
    protected virtual void CreateProjectIndexingTasks(IEnumerable<TKey> keys)
    {
        var projectIds = LoadRelatedProjects(keys);

        CreateTasks(IndexingTaskType.Project, projectIds);
    }

    /// <summary>
    /// Creates donors indexing tasks for all donors depeding on entities of given type with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    protected virtual void CreateDonorIndexingTasks(IEnumerable<TKey> keys)
    {
        var donorIds = LoadRelatedDonors(keys);

        CreateTasks(IndexingTaskType.Donor, donorIds);
    }

    /// <summary>
    /// Creates images indexing tasks for all images depeding on entities of given type with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    protected virtual void CreateImageIndexingTasks(IEnumerable<TKey> keys)
    {
        var imageIds = LoadRelatedImages(keys);

        CreateTasks(IndexingTaskType.Image, imageIds);
    }

    /// <summary>
    /// Creates specimens indexing tasks for all specimens depeding on entities of given type with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    protected virtual void CreateSpecimenIndexingTasks(IEnumerable<TKey> keys)
    {
        var specimenIds = LoadRelatedSpecimens(keys);

        CreateTasks(IndexingTaskType.Specimen, specimenIds);
    }

    /// <summary>
    /// Creates genes indexing tasks for all genes depeding on entities of given type with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    protected virtual void CreateGeneIndexingTasks(IEnumerable<TKey> keys)
    {
        var geneIds = LoadRelatedGenes(keys);

        CreateTasks(IndexingTaskType.Gene, geneIds);
    }

    /// <summary>
    /// Creates variants indexing tasks for all variants depeding on entities of given type with given keys.
    /// </summary>
    /// <param name="keys">Identifiers of entities.</param>
    protected virtual void CreateVariantIndexingTasks(IEnumerable<TKey> keys)
    {
        var ssmIds = LoadRelatedSsms(keys);

        CreateTasks(IndexingTaskType.SSM, ssmIds);


        var cnvIds = LoadRelatedCnvs(keys);

        CreateTasks(IndexingTaskType.CNV, cnvIds);


        var svIds = LoadRelatedSvs(keys);

        CreateTasks(IndexingTaskType.SV, svIds);
    }
}
