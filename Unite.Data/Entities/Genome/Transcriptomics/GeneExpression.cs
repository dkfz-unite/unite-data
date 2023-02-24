using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Entities.Genome.Transcriptomics;

public class GeneExpression
{
	public int GeneId { get; set; }
    public int AnalysedSampleId { get; set; }

    public int Reads { get; set; }
    public double TPM { get; set; }
    public double FPKM { get; set; }

    public virtual Gene Gene { get; set; }
    public virtual AnalysedSample AnalysedSample { get; set; }
}
