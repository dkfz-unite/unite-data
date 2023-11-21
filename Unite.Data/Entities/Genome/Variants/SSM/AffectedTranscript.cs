namespace Unite.Data.Entities.Genome.Variants.SSM;

/// <summary>
/// Simple somatic mutation (SSM) affected transcript
/// </summary>
public record AffectedTranscript : VariantAffectedTranscript<Variant>
{
    public string AminoAcidChange { get; set; }
    public string CodonChange { get; set; }
}
