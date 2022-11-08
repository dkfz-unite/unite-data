namespace Unite.Data.Entities.Genome.Variants.CNV;

/// <summary>
/// Copy number variant (CNV) affected transcript
/// </summary>
public class AffectedTranscript : VariantAffectedFeature<Variant, Transcript>
{
    public int? Distance { get; set; }
    public int? OverlapBpNumber { get; set; }
    public double? OverlapPercentage { get; set; }
}
