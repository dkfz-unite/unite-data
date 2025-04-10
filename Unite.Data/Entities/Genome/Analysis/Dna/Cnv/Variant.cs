using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Genome.Analysis.Dna.Cnv.Enums;

namespace Unite.Data.Entities.Genome.Analysis.Dna.Cnv;

/// <summary>
/// Copy number variant (CNV).
/// </summary>
public record Variant : Dna.Variant
{
    /// <summary>
    /// Copy number alteration type.
    /// </summary>
    [Column("type_id")]
    public CnvType TypeId { get; set; }

    /// <summary>
    /// Loss of heterozygosity (either C1 or C2 are 0).
    /// </summary>
    [Column("loh")]
    public bool? Loh { get; set; }

    /// <summary>
    /// Homozygous deletion (both C1 and C2 are 0).
    /// </summary>
    [Column("del")]
    public bool? Del { get; set; }

    /// <summary>
    /// Mean number of copies in minor allele.
    /// </summary>
    [Column("c1_mean")]
    public double? C1Mean { get; set; }

    /// <summary>
    /// Mean number of copies in major allele.
    /// </summary>
    [Column("c2_mean")]
    public double? C2Mean { get; set; }

    /// <summary>
    /// Mean total number of copies (C1Mean + C2Mean).
    /// </summary>
    [Column("tcn_mean")]
    public double? TcnMean { get; set; }

    /// <summary>
    /// Rounded number of copies in minor allele (-1 for subclonal values if values is 0.3+ far from closest integer).
    /// </summary>
    [Column("c1")]
    public int? C1 { get; set; }

    /// <summary>
    /// Rounded number of copies in major allele (-1 for subclonal values if values is 0.3+ far from closest integer).
    /// </summary>
    [Column("c2")]
    public int? C2 { get; set; }

    /// <summary>
    /// Rounded total number of copies (-1 for subclonal values if values is 0.3+ far from closest integer).
    /// </summary>
    [Column("tcn")]
    public int? Tcn { get; set; }

    /// <summary>
    /// Ratio of total number of copies to sample ploidy.
    /// </summary>
    [Column("tcn_ratio")]
    public double? TcnRatio { get; set; }

    /// <summary>
    /// Estimated maximum decrease of heterozygosity.
    /// </summary>
    [Column("dh_max")]
    public double? DhMax { get; set; }


    /// <summary>
    /// Occurrences of the variant in analysed sample.
    /// </summary>
    public virtual ICollection<VariantEntry> Entries { get; set; }

    /// <summary>
    /// Transcripts affected by the variant.
    /// </summary>
    public virtual ICollection<AffectedTranscript> AffectedTranscripts { get; set; }
}
