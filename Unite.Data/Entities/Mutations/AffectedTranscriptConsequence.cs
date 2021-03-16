using Unite.Data.Entities.Mutations.Enums;

namespace Unite.Data.Entities.Mutations
{
    public class AffectedTranscriptConsequence
    {
        public int AffectedTranscriptId { get; set; }
        public ConsequenceType ConsequenceId { get; set; }

        public virtual AffectedTranscript AffectedTranscript { get; set; }
        public virtual Consequence Consequence { get; set; }
    }
}
