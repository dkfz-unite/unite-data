using Unite.Data.Entities.Genome.Base;
using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Entities.Genome;

public record Transcript : IStableEntity, IStrandedDnaEntity
{
    public int Id { get; set; }
    public string StableId { get; set; }

    public int? GeneId { get; set; }

    public Chromosome? ChromosomeId { get; set; }
    public int? Start { get; set; }
    public int? End { get; set; }
    public bool? Strand { get; set; }
    public int? ExonicLength { get; set; }

    public string Symbol { get; set; }
    public string Description { get; set; }
    public string Biotype { get; set; }
    public bool? IsCanonical { get; set; }

    public virtual Gene Gene { get; set; }
    public virtual Protein Protein { get; set; }
}
