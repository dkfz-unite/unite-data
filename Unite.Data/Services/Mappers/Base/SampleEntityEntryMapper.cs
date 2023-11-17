using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Base;

namespace Unite.Data.Services.Mappers.Base;

internal abstract class SampleEntityEntryMapper<TEntityEntry, TEntity, T> : IEntityTypeConfiguration<TEntityEntry>
    where TEntityEntry : SampleEntityEntry<T>
    where TEntity : Entity<T>
{
    public abstract string TableName { get; }
    public abstract string SchemaName { get; }
    
    public virtual string EntityColumnName => "EntityId";
    public virtual string SampleColumnName => "SampleId";


    public virtual void Configure(EntityTypeBuilder<TEntityEntry> entity)
    {
        entity.ToTable(TableName, SchemaName);

        entity.HasKey(entry => new
        {
            entry.EntityId,
            entry.SampleId
        });

        entity.Property(entry => entry.EntityId)
              .HasColumnName(EntityColumnName)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(entry => entry.SampleId)
              .HasColumnName(SampleColumnName)
              .IsRequired()
              .ValueGeneratedNever();
    }
}
