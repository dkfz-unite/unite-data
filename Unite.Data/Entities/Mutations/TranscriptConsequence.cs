using Unite.Data.Entities.Mutations.Enums;

namespace Unite.Data.Entities.Mutations
{
    public class TranscriptConsequence
    {
        public int Id { get; set; }
        public int MutationId { get; set; }
        public int TranscriptId { get; set; }
        public ConsequenceType ConsequenceId { get; set; }
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
        public virtual Consequence Consequence { get; set; }
    }
}
