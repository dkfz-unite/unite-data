using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Omics.Analysis.Prot;

public record ProteinExpression : Base.SampleEntry<Sample, Protein>
{
    [Column("raw")]
    public double Raw { get; set; }

    /// <summary>
    /// Normalized value: log2(Raw + 1) - Median(log2(Raw + 1)). Used by filters for sample to sample comparison.
    /// </summary>
    [Column("normalized")]
    public double Normalized { get; set; }
}
