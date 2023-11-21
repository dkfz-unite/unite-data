namespace Unite.Data.Entities.Base;

/// <summary>
/// Occurrence of the feature in the sample during the analysis.
/// </summary> 
public record AnalysisFeatureEntry
{
    public long FeatureId { get; set; }
    public int AnalysedSampleId { get; set; }
}

/// <summary>
/// Occurrence of the feature in the sample during the analysis.
/// </summary>
/// <typeparam name="TAnalysedSample">Analysed sample type.</typeparam>
/// <typeparam name="TAnalysis">Analysis type.</typeparam>
/// <typeparam name="TSample">Sample type.</typeparam>
/// <typeparam name="TFeature">Feature type.</typeparam>
public record AnalysisFeatureEntry<TAnalysedSample, TAnalysis, TSample, TFeature> : AnalysisFeatureEntry
    where TAnalysedSample : AnalysedSample<TAnalysis, TSample>
    where TAnalysis : Analysis
    where TSample : Sample
    where TFeature : class
{
    public virtual TFeature Feature { get; set; }
    public virtual TAnalysedSample AnalysedSample { get; set; }
}
