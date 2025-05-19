using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Entities.Omics;

public record Transcript : Feature
{
    [Column("id")]
    public int Id { get; set; }
    [Column("stable_id")]
    public string StableId { get; set; }

    [Column("gene_id")]
    public int? GeneId { get; set; }

    [Column("chromosome_id")]
    public Chromosome? ChromosomeId { get; set; }
    [Column("start")]
    public int? Start { get; set; }
    [Column("end")]
    public int? End { get; set; }
    [Column("strand")]
    public bool? Strand { get; set; }
    [Column("exonic_length")]
    public int? ExonicLength { get; set; }

    [Column("symbol")]
    public string Symbol { get; set; }
    [Column("biotype")]
    public string Biotype { get; set; }
    [Column("is_canonical")]
    public bool? IsCanonical { get; set; }
    [Column("description")]
    public string Description { get; set; }

    public virtual Gene Gene { get; set; }
    public virtual Protein Protein { get; set; }
}
