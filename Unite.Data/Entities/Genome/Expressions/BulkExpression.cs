namespace Unite.Data.Entities.Genome.Expressions;

public record BulkExpression : Entities.Base.AnalysisFeatureEntry<Specimens.Analysis.AnalysedSample, Specimens.Analysis.Analysis, Specimens.Specimen, Gene>
{
    public int Reads { get; set; }
    public double TPM { get; set; }
    public double FPKM { get; set; }
}
