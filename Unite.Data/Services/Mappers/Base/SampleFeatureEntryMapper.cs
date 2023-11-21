using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unite.Data.Services.Mappers.Base;

internal abstract class SampleFeatureEntryMapper<TFeatureEntry, TFeature> : IEntityTypeConfiguration<TFeatureEntry>
    where TFeatureEntry : Entities.Base.SampleFeatureEntry
    where TFeature : class
{
    public abstract string TableName { get; }
    public abstract string SchemaName { get; }
    
    public virtual string FeatureColumnName => "FeatureId";
    public virtual string SampleColumnName => "SampleId";


    public virtual void Configure(EntityTypeBuilder<TFeatureEntry> entity)
    {
        entity.ToTable(TableName, SchemaName);

        entity.HasKey(entry => new
        {
            entry.FeatureId,
            entry.SampleId
        });

        entity.Property(entry => entry.FeatureId)
              .HasColumnName(FeatureColumnName)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(entry => entry.SampleId)
              .HasColumnName(SampleColumnName)
              .IsRequired()
              .ValueGeneratedNever();
    }
}
