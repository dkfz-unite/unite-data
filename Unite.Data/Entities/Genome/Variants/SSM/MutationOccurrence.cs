using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Entities.Genome.Variants.SSM
{
    public class MutationOccurrence
    {
        public long VariantId { get; set; }
        public int AnalysedSampleId { get; set; }

        public virtual Mutation Variant { get; set; }
        public virtual AnalysedSample AnalysedSample { get; set; }
    }
}
