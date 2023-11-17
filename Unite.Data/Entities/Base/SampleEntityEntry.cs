using System.Numerics;

namespace Unite.Data.Entities.Base;

/// <summary>
/// Occurrence of the entity in the sample.
/// </summary>
/// <typeparam name="T">Id type of the entity.</typeparam> 
public abstract record SampleEntityEntry<T>
{
    public T EntityId { get; set; }
    public int SampleId { get; set; }
}

/// <summary>
/// Occurrence of the entity in the sample.
/// </summary>
/// <typeparam name="TSample">Sample type.</typeparam>
/// <typeparam name="TEntity">Entity type.</typeparam>
/// <typeparam name="T">Id type of the entity.</typeparam> 
public abstract record SampleEntityEntry<TSample, TEntity, T> : SampleEntityEntry<T>
    where TSample : Sample
    where TEntity : Entity<T>
{
    public virtual TEntity Entity { get; set; }
    public virtual TSample Sample { get; set; }
}
