using Unite.Data.Entities.Genome.Analysis.Dna.Ssm.Enums;

namespace Unite.Data.Entities.Genome.Analysis.Dna.Ssm;

/// <summary>
/// Simple somatic mutation (SSM).
/// </summary>
public record Variant : Dna.Variant
{
    /// <summary>
    /// Simple somatic mutation type.
    /// </summary>
    public SsmType TypeId { get; set; }

    /// <summary>
    /// Reference genomic sequence of chromosome region.
    /// </summary>
    public string Ref { get; set; }

    /// <summary>
    /// Alternate genomic sequence of chromosome region.
    /// </summary>
    public string Alt { get; set; }


    /// <summary>
    /// Occurrences of the variant in analysed sample.
    /// </summary>
    public virtual ICollection<VariantEntry> Entries { get; set; }

    /// <summary>
    /// Transcripts affected by the variant.
    /// </summary>
    public virtual ICollection<AffectedTranscript> AffectedTranscripts { get; set; }
}
