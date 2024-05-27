namespace Unite.Data.Entities.Images.Analysis.Radiomics;

public record FeatureEntry : Base.SampleEntry<Sample, Feature>
{
    public string Value { get; set; }
}
