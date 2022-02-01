namespace Unite.Data.Entities.Images
{
    public class ImageFeatureOccurrence
    {
        public long Id { get; set; }
        public int AnalysedImageId { get; set; }
        public int FeatureId { get; set; }

        public string Value { get; set; }


        public virtual AnalysedImage AnalysedImage { get; set; }
        public virtual ImageFeature Feature { get; set; }
    }
}
