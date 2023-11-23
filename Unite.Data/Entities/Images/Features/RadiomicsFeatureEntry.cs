using Unite.Data.Entities.Images.Analysis;

namespace Unite.Data.Entities.Images.Features;

public record RadiomicsFeatureEntry : Base.AnalysedSampleEntry<AnalysedSample, RadiomicsFeature, int>
{
    public string Value { get; set; }
}
