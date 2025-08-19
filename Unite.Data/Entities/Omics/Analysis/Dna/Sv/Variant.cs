using Unite.Data.Entities.Omics.Enums;
using Unite.Data.Entities.Omics.Analysis.Dna.Sv.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Omics.Analysis.Dna.Sv;

/// <summary>
/// Structural variant (SV).
/// </summary>
public record Variant : Dna.Variant
{
    /// <summary>
    /// Second breakpoint chromosome.
    /// </summary>
    [Column("other_chromosome_id")]
    public Chromosome OtherChromosomeId { get; set; }

    /// <summary>
    /// Second breakpoint start.
    /// </summary>
    [Column("other_start")]
    public int OtherStart { get; set; }

    /// <summary>
    /// Second breakpoint end.
    /// </summary>
    [Column("other_end")]
    public int OtherEnd { get; set; }

    /// <summary>
    /// Structural variant type.
    /// </summary>
    [Column("type_id")]
    public SvType TypeId { get; set; }

    /// <summary>
    /// Whether event is inverted or not.
    /// </summary>
    [Column("inverted")]
    public bool? Inverted { get; set; }

    /// <summary>
    /// Flanking genomic sequence 200bp around first breakpoint.
    /// </summary>
    [Column("flanking_sequence_from")]
    public string FlankingSequenceFrom { get; set; }

    /// <summary>
    /// Flanking genomic sequence 200bp around second breakpoint.
    /// </summary>
    [Column("flanking_sequence_to")]
    public string FlankingSequenceTo { get; set; }

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
