using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Base;

namespace Unite.Data.Context.Mappers.Base;

internal abstract class AnalysedSampleEntryMapper<TAnalysedSampleEntry, TAnalysedSample, TEntity, T> : IEntityTypeConfiguration<TAnalysedSampleEntry>
    where TAnalysedSampleEntry : AnalysedSampleEntry<TAnalysedSample, TEntity, T>
    where TAnalysedSample : AnalysedSample
    where TEntity : Entity<T>
    where T : struct
{
    protected abstract string SchemaName { get; }
    protected abstract string TableName { get; }
    
    protected virtual string AnalysedSampleColumnName => "AnalysedSampleId";
    protected virtual string EntityColumnName => "EntityId";

    public virtual void Configure(EntityTypeBuilder<TAnalysedSampleEntry> entity)
    {
        entity.ToTable(TableName, SchemaName);

        entity.HasKey(entity => new { entity.AnalysedSampleId, entity.EntityId });

        entity.Property(entity => entity.AnalysedSampleId)
              .HasColumnName(AnalysedSampleColumnName)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(entity => entity.EntityId)
              .HasColumnName(EntityColumnName)
              .IsRequired()
              .ValueGeneratedNever();
    }
}
