namespace Unite.Data.Entities.Base;

/// <summary>
/// Sample analysed by the analysis.
/// </summary>
public abstract record AnalysedSample
{
    public int Id { get; set; }
    public string ReferenceId { get; set; }
    
    public int AnalysisId { get; set; }
    public int TargetSampleId { get; set; }
    public int? MatchedSampleId { get; set; }
}

/// <summary>
/// Typed sample analysed by the analysis.
/// </summary>
/// <typeparam name="TAnalysis">Analysis type.</typeparam> 
/// <typeparam name="TSample">Sample type.</typeparam>
public abstract record AnalysedSample<TAnalysis, TSample> : AnalysedSample
    where TAnalysis : Analysis
    where TSample : Sample
{
    public virtual TAnalysis Analysis { get; set; }
    public virtual TSample TargetSample { get; set; }
    public virtual TSample MatchedSample { get; set; }
}
