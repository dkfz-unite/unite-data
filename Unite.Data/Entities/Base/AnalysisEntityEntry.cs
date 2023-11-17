using System.Numerics;

namespace Unite.Data.Entities.Base;

/// <summary>
/// Occurrence of the entity in the sample during the analysis.
/// </summary>
/// <typeparam name="T">Id type of the entity.</typeparam> 
public record AnalysisEntityEntry<T>
{
    public T EntityId { get; set; }
    public int AnalysedSampleId { get; set; }
}

/// <summary>
/// Occurrence of the entity in the sample during the analysis.
/// </summary>
/// <typeparam name="TAnalysedSample">Analysed sample type.</typeparam>
/// <typeparam name="TAnalysis">Analysis type.</typeparam>
/// <typeparam name="TSample">Sample type.</typeparam>
/// <typeparam name="TEntity">Entity type.</typeparam>
/// <typeparam name="T">Id type of the entity.</typeparam>
public record AnalysisEntityEntry<TAnalysedSample, TAnalysis, TSample, TEntity, T> : AnalysisEntityEntry<T>
    where TAnalysedSample : AnalysedSample<TAnalysis, TSample>
    where TAnalysis : Analysis
    where TSample : Sample
    where TEntity : Entity<T>
{
    public virtual TEntity Entity { get; set; }
    public virtual TAnalysedSample AnalysedSample { get; set; }
}
