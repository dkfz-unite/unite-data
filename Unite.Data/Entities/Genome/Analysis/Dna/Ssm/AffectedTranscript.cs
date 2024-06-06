namespace Unite.Data.Entities.Genome.Analysis.Dna.Ssm;

/// <summary>
/// Simple somatic mutation (SSM) affected transcript
/// </summary>
public record AffectedTranscript : VariantAffectedTranscript<Variant>
{
    public string ProteinChange { get; set; }
    public string CodonChange { get; set; }
}
