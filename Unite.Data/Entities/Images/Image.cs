using Unite.Data.Entities.Images.Analysis;
using Unite.Data.Entities.Images.Enums;

namespace Unite.Data.Entities.Images;

public record Image : Base.Sample<ImageType>
{
    public virtual MriImage MriImage { get; set; }
    
    public virtual ICollection<AnalysedSample> AnalysedSamples { get; set; }
    public virtual ICollection<AnalysedSample> MatchedSamples { get; set; }
}
