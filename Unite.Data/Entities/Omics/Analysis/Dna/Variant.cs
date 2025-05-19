using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Entities.Omics.Analysis.Dna;

public abstract record Variant : Base.Entity
{
    /// <summary>
    /// Chromosome.
    /// </summary>
    [Column("chromosome_id")]
    public Chromosome ChromosomeId { get; set; }

    /// <summary>
    /// Chromosome region start.
    /// </summary>
    [Column("start")]
    public int Start { get; set; }

    /// <summary>
    /// Chromosome region end.
    /// </summary>
    [Column("end")]
    public int End { get; set; }

    /// <summary>
    /// Number of base pairs affected by the variant.
    /// </summary>
    [Column("length")]
    public int? Length { get; set; }
}
