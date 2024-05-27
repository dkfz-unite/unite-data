namespace Unite.Data.Entities.Base;

public abstract record Sample
{
    public int Id { get; set; }

    public int SpecimenId { get; set; }
    public int AnalysisId { get; set; }
}

public abstract record Sample<TSpecimen, TAnalysis> : Sample
    where TSpecimen : Specimen
    where TAnalysis : Analysis
{
    public virtual TSpecimen Specimen { get; set; }
    public virtual TAnalysis Analysis { get; set; }
}
