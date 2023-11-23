namespace Unite.Data.Entities.Base;

public abstract record AnalysedSample
{
    public int Id { get; set; }

    public int AnalysisId { get; set; }
    public int TargetSampleId { get; set; }
    public int? MatchedSampleId { get; set; }
}

public abstract record AnalysedSample<TAnalysis, TSample> : AnalysedSample
    where TAnalysis : Analysis
    where TSample : Sample
{
    public virtual TAnalysis Analysis { get; set; }
    public virtual TSample TargetSample { get; set; }
    public virtual TSample MatchedSample { get; set; }
}
