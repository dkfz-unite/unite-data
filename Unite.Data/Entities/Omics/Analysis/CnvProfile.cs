using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Entities.Omics.Analysis;

public record CnvProfile: Base.Entity
{
    public int SampleId { get; set; }
    public Sample Sample { get; set; }
    public Chromosome Chromosome { get; set; }
    public ChromosomeArm ChromosomeArm { get; set; }
    public float Gain { get; set; }
    public float Loss { get; set; }
    public float Neutral { get; set; }
}