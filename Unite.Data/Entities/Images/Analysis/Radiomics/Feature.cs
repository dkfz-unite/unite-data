namespace Unite.Data.Entities.Images.Analysis.Radiomics;

public record Feature : Base.Entity
{
    public string Name { get; set; }

    public ICollection<FeatureEntry> Entries { get; set; }
}
