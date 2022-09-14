using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Entities.Genome;

public class Transcript
{
    public int Id { get; set; }

    public int? GeneId { get; set; }
    public int? ProteinId { get; set; }
    public string Symbol { get; set; }
    public Chromosome? ChromosomeId { get; set; }
    public int? Start { get; set; }
    public int? End { get; set; }
    public bool? Strand { get; set; }
    public string Biotype { get; set; }

    public virtual Gene Gene { get; set; }
    public virtual Protein Protein { get; set; }

    public virtual TranscriptInfo Info { get; set; }
}
