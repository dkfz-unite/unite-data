using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Variants.SSM.Enums;

namespace Unite.Data.Entities.Genome.Variants.SSM;

/// <summary>
/// Simple Somatic Mutation (SSM) 
/// </summary>
public class Mutation
{
    public long Id { get; set; }
    public string Code { get; set; }
    public MutationType TypeId { get; set; }
    public Chromosome ChromosomeId { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    public string ReferenceBase { get; set; }
    public string AlternateBase { get; set; }

    public virtual ICollection<MutationOccurrence> Occurrences { get; set; }
    public virtual ICollection<AffectedTranscript> AffectedTranscripts { get; set; }
}
