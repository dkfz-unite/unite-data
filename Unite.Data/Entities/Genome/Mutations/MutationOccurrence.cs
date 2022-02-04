namespace Unite.Data.Entities.Genome.Mutations
{
    public class MutationOccurrence
    {
        public long Id { get; set; }

        public int SampleId { get; set; }
        public long MutationId { get; set; }

        public virtual Sample Sample { get; set; }
        public virtual Mutation Mutation { get; set; }
    }
}
