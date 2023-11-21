using Unite.Data.Entities.Images.Analysis;

namespace Unite.Data.Entities.Images.Features;

public record RadiomicsFeatureEntry
{
    public int FeatureId { get; set; }
    public int AnalysedImageId { get; set; }

    public string Value { get; set; }

    public virtual RadiomicsFeature Feature { get; set; }
    public virtual AnalysedImage AnalysedImage { get; set; }
}
