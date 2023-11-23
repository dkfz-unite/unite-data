using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Entities.Genome.Transcriptomics;

public record BulkExpression : Base.AnalysedSampleEntry<AnalysedSample, Gene, int>
{
    public int Reads { get; set; }
    public double TPM { get; set; }
    public double FPKM { get; set; }
}
