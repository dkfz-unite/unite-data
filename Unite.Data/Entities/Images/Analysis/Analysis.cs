using Unite.Data.Entities.Images.Analysis.Enums;

namespace Unite.Data.Entities.Images.Analysis;

public record Analysis : Base.Analysis<AnalysisType>
{
    public virtual ICollection<AnalysedSample> AnalysedSamples { get; set; }
}
