namespace Unite.Data.Entities.Images.Features
{
    public class AnalysisParameterOccurrence
    {
        public long Id { get; set; }
        public int AnalysisId { get; set; }
        public int ParameterId { get; set; }

        public string Value { get; set; }


        public virtual Analysis Analysis { get; set; }
        public virtual AnalysisParameter Parameter { get; set; }
    }
}
