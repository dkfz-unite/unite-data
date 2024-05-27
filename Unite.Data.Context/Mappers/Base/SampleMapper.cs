using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Base;

namespace Unite.Data.Context.Mappers.Base;

internal abstract class SampleMapper<TSample> : IEntityTypeConfiguration<TSample>
    where TSample : Sample
{
    protected abstract string SchemaName { get; }
    protected virtual string TableName => "Samples";
    protected virtual string SpecimenColumnName => "SpecimenId";
    protected virtual string AnalysisColumnName => "AnalysisId";

    public virtual void Configure(EntityTypeBuilder<TSample> entity)
    {
        entity.ToTable(TableName, SchemaName);

        entity.HasKey(sample => sample.Id);

        entity.Property(sample => sample.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(sample => sample.SpecimenId)
              .HasColumnName(SpecimenColumnName)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(sample => sample.AnalysisId)
              .HasColumnName(AnalysisColumnName)
              .IsRequired()
              .ValueGeneratedNever();
    }
}
