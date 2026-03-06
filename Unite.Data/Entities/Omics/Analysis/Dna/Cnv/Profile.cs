using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Entities.Omics.Analysis.Dna.Cnv;

public record Profile: Base.Entity
{
    [Column("sample_id")]
    public int SampleId { get; set; }

    
    [Column("chromosome_id")]
    public Chromosome ChromosomeId { get; set; }
    [Column("chromosome_arm_id")]
    public ChromosomeArm ChromosomeArmId { get; set; }
    [Column("gain")]
    public double Gain { get; set; }
    [Column("loss")]
    public double Loss { get; set; }
    [Column("neutral")]
    public double Neutral { get; set; }

    public virtual Sample Sample { get; set; }
}
