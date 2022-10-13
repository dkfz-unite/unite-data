namespace Unite.Data.Entities.Genome.Variants.SSM;

/// <summary>
/// Simple somatic mutation (SSM) affected transcript
/// </summary>
public class AffectedTranscript : VariantAffectedFeature<Variant, Transcript>
{
    public int? CDNAStart { get; set; }
    public int? CDNAEnd { get; set; }
    public int? CDSStart { get; set; }
    public int? CDSEnd { get; set; }
    public int? ProteinStart { get; set; }
    public int? ProteinEnd { get; set; }
    public string AminoAcidChange { get; set; }
    public string CodonChange { get; set; }
}
