namespace Unite.Data.Entities.Mutations
{
    public class MutationOccurrence
    {
        public int Id { get; set; }
        public int AnalysedSampleId { get; set; }
        public int MutationId { get; set; }

        public virtual AnalysedSample AnalysedSample { get; set; }
        public virtual Mutation Mutation { get; set; }
    }
}
