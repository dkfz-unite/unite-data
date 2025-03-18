using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Base;

namespace Unite.Data.Context.Mappers.Base;

internal abstract class SampleResourceMapper<TSampleResource> : IEntityTypeConfiguration<TSampleResource>
    where TSampleResource : SampleResource
{
    protected abstract string SchemaName { get; }

    public virtual void Configure(EntityTypeBuilder<TSampleResource> entity)
    {
        entity.ToTable("SampleResources", SchemaName);

        entity.HasKey(resource => resource.Id);

        entity.Property(resource => resource.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(resource => resource.SampleId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(resource => resource.Name)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(resource => resource.Type)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(resource => resource.Format)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(resource => resource.Archive)
              .HasMaxLength(100);
    }
}
