namespace Unite.Data.Entities.Images.Features;

public record RadiomicsFeature : Base.Entity<int>
{
    public string Name { get; set; }

    public ICollection<RadiomicsFeatureEntry> Entries { get; set; }
}
