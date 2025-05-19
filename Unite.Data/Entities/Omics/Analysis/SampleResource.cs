namespace Unite.Data.Entities.Omics.Analysis;

public record SampleResource : Base.SampleResource
{
    public virtual Sample Sample { get; set; }
}
