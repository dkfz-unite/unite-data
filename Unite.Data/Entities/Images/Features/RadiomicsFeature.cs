namespace Unite.Data.Entities.Images.Features;

public record RadiomicsFeature
{
    public int Id { get; set; }

    public string Name { get; set; }


    public ICollection<RadiomicsFeatureEntry> Entries { get; set; }
}
