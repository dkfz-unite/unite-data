namespace Unite.Data.Entities.Genome.Mutations;

public class MutationOccurrence
{
    public long Id { get; set; }

    public int AnalysedSampleId { get; set; }
    public long MutationId { get; set; }

    public virtual AnalysedSample AnalysedSample { get; set; }
    public virtual Mutation Mutation { get; set; }
}
