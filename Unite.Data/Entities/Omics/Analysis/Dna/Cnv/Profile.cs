using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Entities.Omics.Analysis.Dna.Cnv;

public record Profile: Base.Entity
{
    [Column("sample_id")]
    public int SampleId { get; set; }
    public Sample Sample { get; set; }
    [Column("chromosome")]
    public Chromosome Chromosome { get; set; }
    [Column("chromosome_arm")]
    public ChromosomeArm ChromosomeArm { get; set; }
    [Column("gain")]
    public float Gain { get; set; }
    [Column("loss")]
    public float Loss { get; set; }
    [Column("neutral")]
    public float Neutral { get; set; }
}