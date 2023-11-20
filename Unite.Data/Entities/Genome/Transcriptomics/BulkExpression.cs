namespace Unite.Data.Entities.Genome.Transcriptomics;

public record BulkExpression : GeneEntry
{
    public int Reads { get; set; }
    public double TPM { get; set; }
    public double FPKM { get; set; }
}
