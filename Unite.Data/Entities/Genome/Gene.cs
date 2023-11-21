using Unite.Data.Entities.Base;
using Unite.Data.Entities.Genome.Base;
using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Expressions;

namespace Unite.Data.Entities.Genome;

public record Gene : Entity<int>, IStableEntity, IStrandedDnaEntity
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
    public virtual ICollection<BulkExpression> BulkExpressions { get; set; }
}
