using Unite.Data.Entities.Genome.Variants.CNV.Enums;

namespace Unite.Data.Entities.Genome.Variants.CNV;

/// <summary>
/// Copy number variant (CNV)
/// </summary>
public class Variant : Variants.Variant
{
    /// <summary>
    /// Structural variant type (SV.Type)
    /// </summary>
    public SvType? SvTypeId { get; set; }

    /// <summary>
    /// Copy number alteration type (CNA.Type)
    /// </summary>
    public CnaType CnaTypeId { get; set; }

    /// <summary>
    /// Loss of heterozygosity (either C1 or C2 are 0)
    /// </summary>
    public bool? Loh { get; set; }

    /// <summary>
    /// Homozygous deletion (both C1 and C2 are 0)
    /// </summary>
    public bool? HomoDel { get; set; }

    /// <summary>
    /// Mean number of copies in minor allele
    /// </summary>
    public double? C1Mean { get; set; }

    /// <summary>
    /// Mean number of copies in major allele
    /// </summary>
    public double? C2Mean { get; set; }

    /// <summary>
    /// Mean total number of copies (C1Mean + C2Mean)
    /// </summary>
    public double? TcnMean { get; set; }

    /// <summary>
    /// Rounded number of copies in minor allele (-1 for subclonal values if values is 0.3+ far from closest integer)
    /// </summary>
    public int? C1 { get; set; }

    /// <summary>
    /// Rounded number of copies in major allele (-1 for subclonal values if values is 0.3+ far from closest integer)
    /// </summary>
    public int? C2 { get; set; }

    /// <summary>
    /// Rounded total number of copies (-1 for subclonal values if values is 0.3+ far from closest integer)
    /// </summary>
    public int? Tcn { get; set; }

    /// <summary>
    /// Estimated maximum decrease of heterozygosity
    /// </summary>
    public double? DhMax { get; set; }


    /// <summary>
    /// Occurrences of the variant in analysed sample
    /// </summary>
    public virtual ICollection<VariantOccurrence> Occurrences { get; set; }

    /// <summary>
    /// Transcripts affected by the variant
    /// </summary>
    public virtual ICollection<AffectedTranscript> AffectedTranscripts { get; set; }
}
