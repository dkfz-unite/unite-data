using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Base;

public abstract record SampleEntry
{
    [Column("sample_id")]
    public int SampleId { get; set; }
    [Column("entity_id")]
    public int EntityId { get; set; }
}

public abstract record SampleEntry<TSample, TEntity> : SampleEntry
    where TSample : Sample
    where TEntity : Entity
{
    public TSample Sample { get; set; }
    public TEntity Entity { get; set; }
}
