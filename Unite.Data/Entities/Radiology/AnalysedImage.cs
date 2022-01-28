using System.Collections.Generic;

namespace Unite.Data.Entities.Radiology
{
    public class AnalysedImage
    {
        public int Id { get; set; }

        public int ImageId { get; set; }
        public int AnalysisId { get; set; }
        

        public virtual Image Image { get; set; }
        public virtual Analysis Analysis { get; set; }

        public virtual ICollection<ImageFeatureOccurrence> FeatureOccurrences { get; set; }
    }
}
