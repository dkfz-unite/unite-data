using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Omics.Analysis.Prot;

public record ProteinExpression : Base.SampleEntry<Sample, Protein>
{
    [Column("intensity")]
    public double Intensity { get; set; }

    [Column("median_centered_log2")]
    public double MedianCenteredLog2 { get; set; }
}
