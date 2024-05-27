using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Analysis.Dna.Sv.Enums;

namespace Unite.Data.Entities.Genome.Analysis.Dna.Sv;

/// <summary>
/// Structural variant (SV).
/// </summary>
public record Variant : Dna.Variant
{
    /// <summary>
    /// Second breakpoint chromosome.
    /// </summary>
    public Chromosome OtherChromosomeId { get; set; }

    /// <summary>
    /// Second breakpoint start.
    /// </summary>
    public int OtherStart { get; set; }

    /// <summary>
    /// Second breakpoint end.
    /// </summary>
    public int OtherEnd { get; set; }

    /// <summary>
    /// Structural variant type.
    /// </summary>
    public SvType TypeId { get; set; }

    /// <summary>
    /// Whether event is inverted or not.
    /// </summary>
    public bool? Inverted { get; set; }

    /// <summary>
    /// Flanking genomic sequence 200bp around first breakpoint.
    /// </summary>
    public string FlankingSequenceFrom { get; set; }

    /// <summary>
    /// Flanking genomic sequence 200bp around second breakpoint.
    /// </summary>
    public string FlankingSequenceTo { get; set; }


    /// <summary>
    /// Occurrences of the variant in analysed sample.
    /// </summary>
    public virtual ICollection<VariantEntry> Entries { get; set; }

    /// <summary>
    /// Transcripts affected by the variant.
    /// </summary>
    public virtual ICollection<AffectedTranscript> AffectedTranscripts { get; set; }
}
