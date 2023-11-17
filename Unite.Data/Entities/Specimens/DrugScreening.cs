namespace Unite.Data.Entities.Specimens;

public record DrugScreening : Base.SampleEntityEntry<Specimen, Drug, int>
{
    /// <summary>
    /// Drug sensitivity score
    /// </summary>
    public double? Dss { get; set; }

    /// <summary>
    /// Selective drug sensitivity score (considering healthy cells)
    /// </summary>
    public double? DssSelective { get; set; }

    /// <summary>
    /// Goodness of fit
    /// </summary>
    public double? Gof { get; set; }

    /// <summary>
    /// Minimal tested concentration
    /// </summary>
    public double? MinConcentration { get; set; }

    /// <summary>
    /// Maximal tested concentration
    /// </summary>
    public double? MaxConcentration { get; set; }

    /// <summary>
    /// Concentration at 25% inhibition (based on the fitted dose-response curve)
    /// </summary>
    public double? AbsIC25 { get; set; }

    /// <summary>
    /// Concentration at 50% inhibition (based on the fitted dose-response curve)
    /// </summary>
    public double? AbsIC50 { get; set; }

    /// <summary>
    /// Concentration at 75% inhibition (based on the fitted dose-response curve)
    /// </summary>
    public double? AbsIC75 { get; set; }

    /// <summary>
    /// Concentration (dose) at corresponding inhibition (response) percent from Inhibition array (selected points on drug response curve)
    /// </summary>
    public double[] Concentration { get; set; }

    /// <summary>
    /// Percent inhibition (response) at corresponding concentration (dose) from Concentration array (selected points on drug response curve)
    /// </summary>
    public double[] Inhibition { get; set; }

    /// <summary>
    /// Concentration (dose) at corresponding inhibition (response) percent from Response array (line of drug response curve)
    /// </summary>
    public double[] ConcentrationLine { get; set; }

    /// <summary>
    /// Percent inhibition (response) at corresponding concentration (dose) from Dose array (line of drug response curve)
    /// </summary>
    public double[] InhibitionLine { get; set; }
}
