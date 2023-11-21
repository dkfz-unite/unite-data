using Unite.Data.Entities.Images.Features;

namespace Unite.Data.Entities.Images.Analysis;

public record AnalysedImage
{
    public int Id { get; set; }

    public int AnalysisId { get; set; }
    public int ImageId { get; set; }


    public virtual Analysis Analysis { get; set; }
    public virtual Image Image { get; set; }

    public virtual ICollection<RadiomicsFeatureEntry> RadiomicsFeatureEntries { get; set; }
}
