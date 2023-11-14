using Unite.Data.Entities.Specimens.Analysis.Enums;

namespace Unite.Data.Entities.Specimens.Analysis;

public record Analysis : Entities.Base.Analysis<AnalysisType>
{
    public virtual ICollection<AnalysedSample> AnalysedSamples { get; set; }
}
