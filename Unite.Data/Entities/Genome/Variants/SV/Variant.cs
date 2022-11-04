﻿using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Variants.SV.Enums;

namespace Unite.Data.Entities.Genome.Variants.SV;

/// <summary>
/// Structural variant (SV)
/// </summary>
public class Variant : Variants.Variant
{
    /// <summary>
    /// Second breakpoint chromosome
    /// </summary>
    public Chromosome OtherChromosomeId { get; set; }

    /// <summary>
    /// Second breakpoint start
    /// </summary>
    public double OtherStart { get; set; }

    /// <summary>
    /// Second breakpoint end
    /// </summary>
    public double OtherEnd { get; set; }

    /// <summary>
    /// Structural variant type
    /// </summary>
    public SvType TypeId { get; set; }

    /// <summary>
    /// Whether event is inverted or not
    /// </summary>
    public bool? Inverted { get; set; }

    /// <summary>
    /// Flanking genomic sequence 200bp around first breakpoint
    /// </summary>
    public string FlankingSequenceFrom { get; set; }

    /// <summary>
    /// Flanking genomic sequence 200bp around second breakpoint
    /// </summary>
    public string FlankingSequenceTo { get; set; }


    /// <summary>
    /// Occurrences of the variant in analysed sample
    /// </summary>
    public virtual ICollection<VariantOccurrence> Occurrences { get; set; }

    /// <summary>
    /// Transcripts affected by the variant
    /// </summary>
    public virtual ICollection<AffectedTranscript> AffectedTranscripts { get; set; }
}
