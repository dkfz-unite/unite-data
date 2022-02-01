using System.Collections.Generic;

namespace Unite.Data.Entities.Genome.Mutations
{
    public class AffectedTranscript
    {
        public long Id { get; set; }

        public long MutationId { get; set; }
        public int TranscriptId { get; set; }

        public int? CDNAStart { get; set; }
        public int? CDNAEnd { get; set; }
        public int? CDSStart { get; set; }
        public int? CDSEnd { get; set; }
        public int? ProteinStart { get; set; }
        public int? ProteinEnd { get; set; }
        public string AminoAcidChange { get; set; }
        public string CodonChange { get; set; }

        public virtual Mutation Mutation { get; set; }
        public virtual Transcript Transcript { get; set; }

        public virtual ICollection<AffectedTranscriptConsequence> Consequences { get; set; }
    }
}
