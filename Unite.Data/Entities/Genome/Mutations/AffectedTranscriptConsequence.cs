using Unite.Data.Entities.Genome.Mutations.Enums;

namespace Unite.Data.Entities.Genome.Mutations;

public class AffectedTranscriptConsequence
{
    public long AffectedTranscriptId { get; set; }
    public ConsequenceType ConsequenceId { get; set; }

    public virtual AffectedTranscript AffectedTranscript { get; set; }
    public virtual Consequence Consequence { get; set; }
}
