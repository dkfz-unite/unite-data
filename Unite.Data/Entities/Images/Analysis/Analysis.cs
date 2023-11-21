using Unite.Data.Entities.Images.Analysis.Enums;

namespace Unite.Data.Entities.Images.Analysis;

public record Analysis : Base.Analysis<AnalysisType>
{
    public virtual AnalysedImage AnalysedImage { get; set; }
}
