using System.Collections.Generic;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Entities.Genome.Mutations
{
    public class Sample
    {
        public int Id { get; set; }

        public int SpecimenId { get; set; }
        public int AnalysisId { get; set; }
        public int? MatchedSampleId { get; set; }


        public virtual Specimen Specimen { get; set; }
        public virtual Analysis Analysis { get; set; }
        public virtual Sample MatchedSample { get; set; }

        public virtual ICollection<MutationOccurrence> MutationOccurrences { get; set; }
    }
}
