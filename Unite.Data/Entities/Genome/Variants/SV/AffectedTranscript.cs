namespace Unite.Data.Entities.Genome.Variants.SV;

/// <summary>
/// Structural variant (SV) affected transcript
/// </summary>
public record AffectedTranscript : VariantAffectedFeature<Variant, Transcript>
{
    public int? Distance { get; set; }
    public int? OverlapBpNumber { get; set; }
    public double? OverlapPercentage { get; set; }

    public int? CDNAStart { get; set; }
    public int? CDNAEnd { get; set; }
    public int? CDSStart { get; set; }
    public int? CDSEnd { get; set; }
    public int? ProteinStart { get; set; }
    public int? ProteinEnd { get; set; }
}
