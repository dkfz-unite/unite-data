using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Base;

public abstract record Sample
{
    [Column("id")]
    public int Id { get; set; }

    [Column("specimen_id")]
    public int SpecimenId { get; set; }
    [Column("analysis_id")]
    public int AnalysisId { get; set; }
}

public abstract record Sample<TSpecimen, TAnalysis> : Sample
    where TSpecimen : Specimen
    where TAnalysis : Analysis
{
    public virtual TSpecimen Specimen { get; set; }
    public virtual TAnalysis Analysis { get; set; }
}
