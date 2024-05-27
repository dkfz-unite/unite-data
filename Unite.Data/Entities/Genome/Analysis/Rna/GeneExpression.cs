namespace Unite.Data.Entities.Genome.Analysis.Rna;

public record GeneExpression : Base.SampleEntry<Sample, Gene>
{
    public int Reads { get; set; }
    public double TPM { get; set; }
    public double FPKM { get; set; }
}
