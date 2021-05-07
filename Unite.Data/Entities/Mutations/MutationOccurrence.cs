namespace Unite.Data.Entities.Mutations
{
    public class MutationOccurrence
    {
        public long Id { get; set; }
        public long MutationId { get; set; }
        public int AnalysedSampleId { get; set; }

        public virtual Mutation Mutation { get; set; }
        public virtual AnalysedSample AnalysedSample { get; set; }
    }
}
