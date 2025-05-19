using Unite.Data.Entities.Omics.Analysis.Enums;

namespace Unite.Data.Entities.Omics.Analysis;

public record Analysis : Base.Analysis<AnalysisType>
{
    public virtual Sample Sample { get; set; }
}
