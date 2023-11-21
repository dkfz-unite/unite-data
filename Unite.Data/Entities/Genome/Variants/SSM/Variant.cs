using Unite.Data.Entities.Genome.Variants.SSM.Enums;

namespace Unite.Data.Entities.Genome.Variants.SSM;

/// <summary>
/// Simple somatic mutation (SSM) 
/// </summary>
public record Variant : Variants.Variant
{
    /// <summary>
    /// Simple somatic mutation type
    /// </summary>
    public SsmType TypeId { get; set; }

    /// <summary>
    /// Reference genomic sequence of chromosome region
    /// </summary>
    public string Ref { get; set; }

    /// <summary>
    /// Alternate genomic sequence of chromosome region
    /// </summary>
    public string Alt { get; set; }


    /// <summary>
    /// Occurrences of the variant in analysed sample
    /// </summary>
    public virtual ICollection<VariantOccurrence> Occurrences { get; set; }

    /// <summary>
    /// Transcripts affected by the variant
    /// </summary>
    public virtual ICollection<AffectedTranscript> AffectedTranscripts { get; set; }
}
