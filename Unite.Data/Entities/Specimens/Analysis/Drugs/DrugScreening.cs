using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Specimens.Analysis.Drugs;

public record DrugScreening : Base.SampleEntry<Sample, Drug>
{
    /// <summary>
    /// Goodness of fit.
    /// </summary>
    [Column("gof")]
    public double? Gof { get; set; }

    /// <summary>
    /// Drug sensitivity score.
    /// </summary>
    [Column("dss")]
    public double? Dss { get; set; }

    /// <summary>
    /// Selective drug sensitivity score (considering healthy cells).
    /// </summary>
    [Column("dss_s")]
    public double? DssS { get; set; }

    /// <summary>
    /// Minimal tested concentration.
    /// </summary>
    [Column("dose_min")]
    public double? DoseMin { get; set; }

    /// <summary>
    /// Maximal tested concentration.
    /// </summary>
    [Column("dose_max")]
    public double? DoseMax { get; set; }

    /// <summary>
    /// Concentration at 25% inhibition (based on the fitted dose-response curve).
    /// </summary>
    [Column("dose_25")]
    public double? Dose25 { get; set; }

    /// <summary>
    /// Concentration at 50% inhibition (based on the fitted dose-response curve).
    /// </summary>
    [Column("dose_50")]
    public double? Dose50 { get; set; }

    /// <summary>
    /// Concentration at 75% inhibition (based on the fitted dose-response curve).
    /// </summary>
    [Column("dose_75")]
    public double? Dose75 { get; set; }

    /// <summary>
    /// Concentration (dose) at corresponding inhibition (response) percent from 'Responses' array (for dose-response curve).
    /// </summary>
    [Column("doses")]
    public double[] Doses { get; set; }

    /// <summary>
    /// Percent inhibition (response) at corresponding concentration (dose) from 'Doses' array (for dose-response curve).
    /// </summary>
    [Column("responses")]
    public double[] Responses { get; set; }
}
