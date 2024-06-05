namespace Unite.Data.Entities.Specimens.Analysis.Drugs;

public record DrugScreening : Base.SampleEntry<Sample, Drug>
{
    /// <summary>
    /// Goodness of fit.
    /// </summary>
    public double? Gof { get; set; }

    /// <summary>
    /// Drug sensitivity score.
    /// </summary>
    public double? Dss { get; set; }

    /// <summary>
    /// Selective drug sensitivity score (considering healthy cells).
    /// </summary>
    public double? DssS { get; set; }

    /// <summary>
    /// Minimal tested concentration.
    /// </summary>
    public double? MinDose { get; set; }

    /// <summary>
    /// Maximal tested concentration.
    /// </summary>
    public double? MaxDose { get; set; }

    /// <summary>
    /// Concentration at 25% inhibition (based on the fitted dose-response curve).
    /// </summary>
    public double? Dose25 { get; set; }

    /// <summary>
    /// Concentration at 50% inhibition (based on the fitted dose-response curve).
    /// </summary>
    public double? Dose50 { get; set; }

    /// <summary>
    /// Concentration at 75% inhibition (based on the fitted dose-response curve).
    /// </summary>
    public double? Dose75 { get; set; }

    /// <summary>
    /// Concentration (dose) at corresponding inhibition (response) percent from 'Responses' array (for dose-response curve).
    /// </summary>
    public double[] Doses { get; set; }

    /// <summary>
    /// Percent inhibition (response) at corresponding concentration (dose) from 'Doses' array (for dose-response curve).
    /// </summary>
    public double[] Responses { get; set; }
}
