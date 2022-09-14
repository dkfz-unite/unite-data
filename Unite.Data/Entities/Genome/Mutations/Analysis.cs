using Unite.Data.Entities.Genome.Mutations.Enums;

namespace Unite.Data.Entities.Genome.Mutations;

public class Analysis
{
    public int Id { get; set; }
    public string ReferenceId { get; set; }

    public AnalysisType? TypeId { get; set; }
    public DateOnly? Date { get; set; }


    public virtual ICollection<AnalysedSample> AnalysedSamples { get; set; }
    public virtual ICollection<AnalysisParameterOccurrence> ParameterOccurrences { get; set; }
}
