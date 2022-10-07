using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Variants.SV.Enums;

namespace Unite.Data.Entities.Genome.Variants.SV;

/// <summary>
/// Structural variant (SV)
/// </summary>
public class Variant : VariantBase
{
    /// <summary>
    /// New chromosome (for translocated or duplicated regions)
    /// </summary>
    public Chromosome? NewChromosomeId { get; set; }

    /// <summary>
    /// New chromosome region start (for translocated or duplicated regions)
    /// </summary>
    public double? NewStart { get; set; }

    /// <summary>
    /// New chromosome region end (for translocated or duplicated regions)
    /// </summary>
    public double? NewEnd { get; set; }

    /// <summary>
    /// Structural variant type
    /// </summary>
    public SvType? TypeId { get; set; }

    /// <summary>
    /// Reference genomic sequence of chromosome region
    /// </summary>
    public string ReferenceBase { get; set; }

    /// <summary>
    /// Alternate genomic sequence of chromosome region
    /// </summary>
    public string AlternateBase { get; set; }


    /// <summary>
    /// Occurrences of the variant in analysed sample
    /// </summary>
    public virtual ICollection<VariantOccurrence> Occurrences { get; set; }

    /// <summary>
    /// Transcripts affected by the variant
    /// </summary>
    public virtual ICollection<AffectedTranscript> AffectedTranscripts { get; set; }
}
