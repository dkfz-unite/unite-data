namespace Unite.Data.Entities.Images.Features;

public record RadiomicsFeatureEntry : Base.AnalysisFeatureEntry<Analysis.AnalysedSample, Analysis.Analysis, Image, RadiomicsFeature>
{
    public string Value { get; set; }
}
