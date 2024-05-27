namespace Unite.Data.Entities.Images.Analysis;

public record Sample : Base.Sample<Image, Analysis>
{
    public virtual ICollection<Radiomics.FeatureEntry> RadiomicsFeatureEntries { get; set; }
}
