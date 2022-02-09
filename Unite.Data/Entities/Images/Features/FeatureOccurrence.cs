namespace Unite.Data.Entities.Images.Features
{
    public class FeatureOccurrence
    {
        public long Id { get; set; }

        public int AnalysedImageId { get; set; }
        public int FeatureId { get; set; }
        public string Value { get; set; }


        public virtual AnalysedImage AnalysedImage { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
