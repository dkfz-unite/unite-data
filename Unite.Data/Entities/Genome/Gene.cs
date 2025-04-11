using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Genome.Analysis.Rna;
using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Entities.Genome;

public record Gene : Base.Entity
{
    [Column("stable_id")]
    public string StableId { get; set; }

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
    [Column("description")]
    public string Description { get; set; }
    
    public virtual ICollection<Transcript> Transcripts { get; set; }
    public virtual ICollection<GeneExpression> GeneExpressions { get; set; }
}
