using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Base;

namespace Unite.Data.Services.Mappers.Base;

internal abstract class EntityMapper<TEntity, T> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity<T>
    where T : struct
{
    protected abstract string TableName { get; }

    public virtual void Configure(EntityTypeBuilder<TEntity> entity)
    {
        entity.ToTable(TableName);

        entity.HasKey(entity => entity.Id);

        entity.Property(entity => entity.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();
    }
}
