using Unite.Data.Entities.Genome.Analysis.Rna;
using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Entities.Genome;

public record Gene : Base.Entity
{
    public string StableId { get; set; }

    public Chromosome? ChromosomeId { get; set; }
    public int? Start { get; set; }
    public int? End { get; set; }
    public bool? Strand { get; set; }
    public int? ExonicLength { get; set; }

    public string Symbol { get; set; }
    public string Description { get; set; }
    public string Biotype { get; set; }

    public virtual ICollection<Transcript> Transcripts { get; set; }
    public virtual ICollection<GeneExpression> GeneExpressions { get; set; }
}
