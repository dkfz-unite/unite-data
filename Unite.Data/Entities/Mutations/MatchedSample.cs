namespace Unite.Data.Entities.Mutations
{
    public class MatchedSample
    {
        public int AnalysedSampleId { get; set; }
        public int MatchedSampleId { get; set; }

        public AnalysedSample Analysed { get; set; }
        public AnalysedSample Matched { get; set; }
    }
}
