using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Entities.Genome;

public class Gene
{
    public int Id { get; set; }

    public string Symbol { get; set; }
    public Chromosome? ChromosomeId { get; set; }
    public int? Start { get; set; }
    public int? End { get; set; }
    public bool? Strand { get; set; }
    public string Biotype { get; set; }

    public virtual GeneInfo Info { get; set; }
}
