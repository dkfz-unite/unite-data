namespace Unite.Data.Entities.Genome.Analysis;

public record SampleResource : Base.SampleResource
{
    public virtual Sample Sample { get; set; }
}
