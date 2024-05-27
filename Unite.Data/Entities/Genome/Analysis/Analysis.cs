using Unite.Data.Entities.Genome.Analysis.Enums;

namespace Unite.Data.Entities.Genome.Analysis;

public record Analysis : Base.Analysis<AnalysisType>
{
    public virtual Sample Sample { get; set; }
}
