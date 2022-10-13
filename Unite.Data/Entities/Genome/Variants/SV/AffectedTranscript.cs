namespace Unite.Data.Entities.Genome.Variants.SV;

/// <summary>
/// Structural variant (SV) affected transcript
/// </summary>
public class AffectedTranscript : VariantAffectedFeature<Variant, Transcript>
{
    public int? Distance { get; set; }
    public int? OverlapBpNumber { get; set; }
    public int? OverlapPercentage { get; set; }
}
