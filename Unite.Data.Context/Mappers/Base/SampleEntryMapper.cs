using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Base;

namespace Unite.Data.Context.Mappers.Base;

internal abstract class SampleEntryMapper<TSampleEntry, TSample, TEntity> : IEntityTypeConfiguration<TSampleEntry>
    where TSampleEntry : SampleEntry<TSample, TEntity>
    where TSample : Sample
    where TEntity : Entity
{
    protected abstract string SchemaName { get; }
    protected abstract string TableName { get; }
    protected virtual string SampleColumnName => "SampleId";
    protected virtual string EntityColumnName => "EntityId";

    public virtual void Configure(EntityTypeBuilder<TSampleEntry> entity)
    {
        entity.ToTable(TableName, SchemaName);

        entity.HasKey(entity => new { entity.SampleId, entity.EntityId });

        entity.Property(entity => entity.SampleId)
              .HasColumnName(SampleColumnName)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(entity => entity.EntityId)
              .HasColumnName(EntityColumnName)
              .IsRequired()
              .ValueGeneratedNever();
    }
}
