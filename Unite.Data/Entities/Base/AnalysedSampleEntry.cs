namespace Unite.Data.Entities.Base;

public abstract record AnalysedSampleEntry<T>
    where T : struct
{
    public int AnalysedSampleId { get; set; }
    public T EntityId { get; set; }
}

public abstract record AnalysedSampleEntry<TAnalysedSample, TEntity, T> : AnalysedSampleEntry<T>
    where TAnalysedSample : AnalysedSample
    where TEntity : Entity<T>
    where T : struct
{
    public TAnalysedSample AnalysedSample { get; set; }
    public TEntity Entity { get; set; }
}
