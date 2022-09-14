using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Entities.Genome.Transcriptome;

public class TranscriptExpression
{
    public int AnalysedSampleId { get; set; }
    public int GeneId { get; set; }

    public double? ReadCount { get; set; }
    public double? ReadCountTPM { get; set; }
    public double? ReadCountFPKM { get; set; }

    public virtual AnalysedSample AnalysedSample { get; set; }
    public virtual Gene Gene { get; set; }
}
