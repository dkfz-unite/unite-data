using System.Collections.Generic;
using Unite.Data.Entities.Samples;

namespace Unite.Data.Entities.Mutations
{
    public class AnalysedSample
    {
        public int Id { get; set; }
        public int AnalysisId { get; set; }
        public int SampleId { get; set; }

        public virtual Analysis Analysis { get; set; }
        public virtual Sample Sample { get; set; }

        public virtual ICollection<MatchedSample> MatchedSamples { get; set; }
        public virtual ICollection<MutationOccurrence> MutationOccurrences { get; set; }
    }
}
