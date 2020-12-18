using Unite.Data.Entities.Mutations;

namespace Unite.Data.Entities.Samples
{
    public class SampleMutation
    {
        public int SampleId { get; set; }
        public int MutationId { get; set; }
        public string Quality { get; set; }
        public string Filter { get; set; }
        public string Info { get; set; }

        public virtual Sample Sample { get; set; }
        public virtual Mutation Mutation { get; set; }
    }
}
