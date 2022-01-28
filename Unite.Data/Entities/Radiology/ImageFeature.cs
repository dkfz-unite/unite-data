using System.Collections.Generic;

namespace Unite.Data.Entities.Radiology
{
    public class ImageFeature
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public ICollection<ImageFeatureOccurrence> FeatureOccurrences { get; set; }
    }
}
