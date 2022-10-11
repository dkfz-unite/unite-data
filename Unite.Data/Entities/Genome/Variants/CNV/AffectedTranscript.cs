namespace Unite.Data.Entities.Genome.Variants.CNV;

/// <summary>
/// Copy number variant (CNV) affected transcript
/// </summary>
public class AffectedTranscript : AffectedTranscriptBase<Variant>
{
    public int? OverlapBpNumber { get; set; }
    public int? OverlapPercentage { get; set; }
}
