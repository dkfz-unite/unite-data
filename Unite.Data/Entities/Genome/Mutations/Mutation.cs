using System.Collections.Generic;
using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Mutations.Enums;

namespace Unite.Data.Entities.Genome.Mutations
{
    public class Mutation
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public Chromosome ChromosomeId { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public MutationType TypeId { get; set; }
        public string ReferenceBase { get; set; }
        public string AlternateBase { get; set; }

        public virtual ICollection<MutationOccurrence> MutationOccurrences { get; set; }
        public virtual ICollection<AffectedTranscript> AffectedTranscripts { get; set; }
    }
}
