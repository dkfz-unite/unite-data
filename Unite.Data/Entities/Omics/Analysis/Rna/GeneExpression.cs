using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Omics.Analysis.Rna;

public record GeneExpression : Base.SampleEntry<Sample, Gene>
{
    [Column("raw")]
    public int Raw { get; set; }

    [Column("tpm")]
    public double TPM { get; set; }

    [Column("fpkm")]
    public double FPKM { get; set; }

    /// <summary>
    /// Normalized value: log2(TPM + 1). Used by filters for sample to sample comparison.
    /// </summary>
    [Column("normalized")]
    public double Normalized { get; set; }
}
