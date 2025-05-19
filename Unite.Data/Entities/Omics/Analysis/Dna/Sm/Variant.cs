using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Omics.Analysis.Dna.Sm.Enums;

namespace Unite.Data.Entities.Omics.Analysis.Dna.Sm;

/// <summary>
/// Simple mutation (SM).
/// </summary>
public record Variant : Dna.Variant
{
    /// <summary>
    /// Simple mutation type.
    /// </summary>
    [Column("type_id")]
    public SmType TypeId { get; set; }

    /// <summary>
    /// Reference genomic sequence of chromosome region.
    /// </summary>
    [Column("ref")]
    public string Ref { get; set; }

    /// <summary>
    /// Alternate genomic sequence of chromosome region.
    /// </summary>
    [Column("alt")]
    public string Alt { get; set; }

    /// <summary>
    /// Transcript with the most severe effect of the variant.
    /// </summary>
    [NotMapped]
    public AffectedTranscript MostAffectedTranscript => AffectedTranscripts?.Order().FirstOrDefault();


    /// <summary>
    /// Occurrences of the variant in analysed sample.
    /// </summary>
    public virtual ICollection<VariantEntry> Entries { get; set; }

    /// <summary>
    /// Transcripts affected by the variant.
    /// </summary>
    public virtual ICollection<AffectedTranscript> AffectedTranscripts { get; set; }
}
