using System.Collections.Generic;

namespace Unite.Data.Entities.Images.Features;

public class AnalysedImage
{
    public int Id { get; set; }

    public int AnalysisId { get; set; }
    public int ImageId { get; set; }


    public virtual Analysis Analysis { get; set; }
    public virtual Image Image { get; set; }

    public virtual ICollection<FeatureOccurrence> FeatureOccurrences { get; set; }
}
