namespace Unite.Data.Entities.Images.Features;

public record Feature
{
    public int Id { get; set; }

    public string Name { get; set; }


    public ICollection<FeatureOccurrence> FeatureOccurrences { get; set; }
}
