using Unite.Data.Entities.Genome.Analysis.Enums;

namespace Unite.Data.Entities.Genome.Analysis;

public record Analysis
{
    public int Id { get; set; }
    public string ReferenceId { get; set; }

    public AnalysisType? TypeId { get; set; }
    public DateOnly? Date { get; set; }
    public Dictionary<string, string> Parameters { get; set; }

    public virtual ICollection<AnalysedSample> AnalysedSamples { get; set; }
}
