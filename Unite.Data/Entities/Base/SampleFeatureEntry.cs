namespace Unite.Data.Entities.Base;

/// <summary>
/// Occurrence of the feature in the sample.
/// </summary>
public abstract record SampleFeatureEntry
{
    public int FeatureId { get; set; }
    public int SampleId { get; set; }
}

/// <summary>
/// Occurrence of the feature in the sample.
/// </summary>
/// <typeparam name="TSample">Sample type.</typeparam>
/// <typeparam name="TFeature">Feature type.</typeparam>
public abstract record SampleFeatureEntry<TSample, TFeature> : SampleFeatureEntry
    where TSample : Sample
    where TFeature : class
{
    public virtual TFeature Feature { get; set; }
    public virtual TSample Sample { get; set; }
}
