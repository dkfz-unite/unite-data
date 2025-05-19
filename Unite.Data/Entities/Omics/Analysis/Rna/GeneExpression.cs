using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Omics.Analysis.Rna;

public record GeneExpression : Base.SampleEntry<Sample, Gene>
{
    [Column("reads")]
    public int Reads { get; set; }
    [Column("tpm")]
    public double TPM { get; set; }
    [Column("fpkm")]
    public double FPKM { get; set; }
}
