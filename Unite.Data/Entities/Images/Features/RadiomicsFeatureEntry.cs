namespace Unite.Data.Entities.Images.Features;

public record RadiomicsFeatureEntry : ImageEntityEntry<RadiomicsFeature, int>
{
    public string Value { get; set; }
}
