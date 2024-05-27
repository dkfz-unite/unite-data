using Unite.Data.Entities.Specimens.Analysis.Enums;

namespace Unite.Data.Entities.Specimens.Analysis;

public record Analysis : Base.Analysis<AnalysisType>
{
    public virtual Sample Sample { get; set; }
}
