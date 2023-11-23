using Unite.Data.Entities.Images.Features;

namespace Unite.Data.Entities.Images.Analysis;

public record AnalysedSample : Base.AnalysedSample<Analysis, Image>
{
    public virtual ICollection<RadiomicsFeatureEntry> RadiomicsFeatureEntries { get; set; }
}
