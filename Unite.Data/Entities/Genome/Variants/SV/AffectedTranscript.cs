namespace Unite.Data.Entities.Genome.Variants.SV;

/// <summary>
/// Structural variant (SV) affected transcript
/// </summary>
public class AffectedTranscript : AffectedTranscriptBase<Variant>
{
    public int? Distance { get; set; }
    public int? OverlapBpNumber { get; set; }
    public int? OverlapPercentage { get; set; }
}
