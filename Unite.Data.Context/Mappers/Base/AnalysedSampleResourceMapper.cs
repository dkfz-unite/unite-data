using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Base;

namespace Unite.Data.Context.Mappers.Base;

internal abstract class AnalysedSampleResourceMapper<TAnalysedSampleResource> : IEntityTypeConfiguration<TAnalysedSampleResource>
    where TAnalysedSampleResource : AnalysedSampleResource
{
    protected abstract string SchemaName { get; }

    public virtual void Configure(EntityTypeBuilder<TAnalysedSampleResource> entity)
    {
        entity.ToTable("Resources", SchemaName);

        entity.HasKey(resource => resource.Id);

        entity.Property(resource => resource.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(resource => resource.AnalysedSampleId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(resource => resource.Type)
              .IsRequired()
              .HasMaxLength(100);
    }
}
