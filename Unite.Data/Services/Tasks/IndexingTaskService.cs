using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Services.Tasks;

public abstract class IndexingTaskService<T, TKey> : TaskService where T : class
{
    protected IndexingTaskService(DomainDbContext dbContext) : base(dbContext)
    {
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
    /// Loads donors related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns>Collection of dependint donors identifiers.</returns>
    protected abstract IEnumerable<int> LoadRelatedDonors(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads images related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns>Collection of dependint images identifiers.</returns>
    protected abstract IEnumerable<int> LoadRelatedImages(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads specimens related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns>Collection of dependint specimens identifiers.</returns>
    protected abstract IEnumerable<int> LoadRelatedSpecimens(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads genes related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns>Collection of dependint genes identifiers.</returns>
    protected abstract IEnumerable<int> LoadRelatedGenes(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads mutations related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns>Collection of dependint mutations identifiers.</returns>
    protected abstract IEnumerable<long> LoadRelatedMutations(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads copy number variants related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns>Collection of dependint copy number variants identifiers.</returns>
    protected abstract IEnumerable<long> LoadRelatedCopyNumberVariants(IEnumerable<TKey> keys);

    /// <summary>
    /// Loads structural variants related to entities of given tasks with given keys.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns>Collection of dependint structural variants identifiers.</returns>
    protected abstract IEnumerable<long> LoadRelatedStructuralVariants(IEnumerable<TKey> keys);


    /// <summary>
    /// Creates donors indexing tasks for all donors depeding on entities of given type with given keys.
    /// </summary>
    /// <param name="keys">Entities keys.</param>
    protected virtual void CreateDonorIndexingTasks(IEnumerable<TKey> keys)
    {
        var donorIds = LoadRelatedDonors(keys);

        CreateTasks(IndexingTaskType.Donor, donorIds);
    }

    /// <summary>
    /// Creates images indexing tasks for all images depeding on entities of given type with given keys.
    /// </summary>
    /// <param name="keys">Entities keys.</param>
    protected virtual void CreateImageIndexingTasks(IEnumerable<TKey> keys)
    {
        var imageIds = LoadRelatedImages(keys);

        CreateTasks(IndexingTaskType.Image, imageIds);
    }

    /// <summary>
    /// Creates specimens indexing tasks for all specimens depeding on entities of given type with given keys.
    /// </summary>
    /// <param name="keys">Entities keys.</param>
    protected virtual void CreateSpecimenIndexingTasks(IEnumerable<TKey> keys)
    {
        var specimenIds = LoadRelatedSpecimens(keys);

        CreateTasks(IndexingTaskType.Specimen, specimenIds);
    }

    /// <summary>
    /// Creates genes indexing tasks for all genes depeding on entities of given type with given keys.
    /// </summary>
    /// <param name="keys">Entities keys.</param>
    protected virtual void CreateGeneIndexingTasks(IEnumerable<TKey> keys)
    {
        var geneIds = LoadRelatedGenes(keys);

        CreateTasks(IndexingTaskType.Gene, geneIds);
    }

    /// <summary>
    /// Creates variants indexing tasks for all variants depeding on entities of given type with given keys.
    /// </summary>
    /// <param name="keys">Entities keys.</param>
    protected virtual void CreateVariantIndexingTasks(IEnumerable<TKey> keys)
    {
        var mutationIds = LoadRelatedMutations(keys);

        CreateTasks(IndexingTaskType.SSM, mutationIds);


        var copyNumberVariantIds = LoadRelatedCopyNumberVariants(keys);

        CreateTasks(IndexingTaskType.CNV, copyNumberVariantIds);


        var structuralVariantIds = LoadRelatedStructuralVariants(keys);

        CreateTasks(IndexingTaskType.SV, structuralVariantIds);
    }
}
