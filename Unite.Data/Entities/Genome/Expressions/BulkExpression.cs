namespace Unite.Data.Entities.Genome.Expressions;

public record BulkExpression : GeneEntry
{
    public int Reads { get; set; }
    public double TPM { get; set; }
    public double FPKM { get; set; }
}
