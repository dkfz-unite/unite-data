using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Genome.Analysis.Dna;

public abstract record VariantAffectedTranscript<TVariant> : VariantAffectedFeature<TVariant, Transcript>
    where TVariant : Variant
{
    [Column("distance")]
    public int? Distance { get; set; }
    [Column("overlap_bp_number")]
    public int? OverlapBpNumber { get; set; }
    [Column("overlap_percentage")]
    public double? OverlapPercentage { get; set; }

    [Column("cdna_start")]
    public int? CDNAStart { get; set; }
    [Column("cdna_end")]
    public int? CDNAEnd { get; set; }
    [Column("cds_start")]
    public int? CDSStart { get; set; }
    [Column("cds_end")]
    public int? CDSEnd { get; set; }
    [Column("aa_start")]
    public int? AAStart { get; set; }
    [Column("aa_end")]
    public int? AAEnd { get; set; }
}
