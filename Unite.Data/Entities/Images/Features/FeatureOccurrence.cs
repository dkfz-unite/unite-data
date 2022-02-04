namespace Unite.Data.Entities.Images.Features
{
    public class FeatureOccurrence
    {
        public long Id { get; set; }

        public int SampleId { get; set; }
        public int FeatureId { get; set; }
        public string Value { get; set; }


        public virtual Sample Sample { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
