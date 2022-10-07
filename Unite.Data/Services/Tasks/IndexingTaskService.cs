using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Services.Tasks;

public abstract class IndexingTaskService<T, TKey> : TaskService where T : class
{
    protected IndexingTaskService(DomainDbContext dbContext) : base(dbContext)
    {
    }

    /// <summary>
    /// Creates only target type indexing tasks for all existing entities of target type
    /// </summary>
    public abstract void CreateTasks();

    /// <summary>
    /// Creates only target type indexing tasks for all entities of target type with given identifiers
    /// </summary>
    /// <param name="keys">Identifiers of entities</param>
    public abstract void CreateTasks(IEnumerable<TKey> keys);

    /// <summary>
    /// Populates all types of indexing tasks for entities of target type with given identifiers
    /// </summary>
    /// <param name="keys">Identifiers of entities</param>
    public abstract void PopulateTasks(IEnumerable<TKey> keys);


    protected abstract IEnumerable<int> LoadRelatedDonors(IEnumerable<TKey> keys);
    protected abstract IEnumerable<int> LoadRelatedImages(IEnumerable<TKey> keys);
    protected abstract IEnumerable<int> LoadRelatedSpecimens(IEnumerable<TKey> keys);
    protected abstract IEnumerable<int> LoadRelatedGenes(IEnumerable<TKey> keys);
    protected abstract IEnumerable<long> LoadRelatedMutations(IEnumerable<TKey> keys);
    protected abstract IEnumerable<long> LoadRelatedCopyNumberVariants(IEnumerable<TKey> keys);
    protected abstract IEnumerable<long> LoadRelatedStructuralVariants(IEnumerable<TKey> keys);


    protected virtual void CreateDonorIndexingTasks(IEnumerable<TKey> keys)
    {
        var donorIds = LoadRelatedDonors(keys);

        CreateTasks(IndexingTaskType.Donor, donorIds);
    }

    protected virtual void CreateImageIndexingTasks(IEnumerable<TKey> keys)
    {
        var imageIds = LoadRelatedImages(keys);

        CreateTasks(IndexingTaskType.Image, imageIds);
    }

    protected virtual void CreateSpecimenIndexingTasks(IEnumerable<TKey> keys)
    {
        var specimenIds = LoadRelatedSpecimens(keys);

        CreateTasks(IndexingTaskType.Specimen, specimenIds);
    }

    protected virtual void CreateGeneIndexingTasks(IEnumerable<TKey> keys)
    {
        var geneIds = LoadRelatedGenes(keys);

        CreateTasks(IndexingTaskType.Gene, geneIds);
    }

    protected virtual void CreateMutationIndexingTasks(IEnumerable<TKey> keys)
    {
        var mutationIds = LoadRelatedMutations(keys);

        CreateTasks(IndexingTaskType.SSM, mutationIds);
    }

    protected virtual void CreateCopyNumberVariantIndexingTasks(IEnumerable<TKey> keys)
    {
        var mutationIds = LoadRelatedMutations(keys);

        CreateTasks(IndexingTaskType.CNV, mutationIds);
    }

    protected virtual void CreateStructuralVariantIndexingTasks(IEnumerable<TKey> keys)
    {
        var mutationIds = LoadRelatedMutations(keys);

        CreateTasks(IndexingTaskType.CNV, mutationIds);
    }
}
