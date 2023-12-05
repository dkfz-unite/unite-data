using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Base;

namespace Unite.Data.Context.Mappers.Base;

internal abstract class AnalysedSampleMapper<TAnalysedSample> : IEntityTypeConfiguration<TAnalysedSample>
    where TAnalysedSample : AnalysedSample
{
    protected abstract string SchemaName { get; }
    protected virtual string TableName => "AnalysedSamples";
    protected virtual string TargetSampleColumnName => "TargetSampleId";
    protected virtual string MatchedSampleColumnName => "MatchedSampleId";

    public virtual void Configure(EntityTypeBuilder<TAnalysedSample> entity)
    {
        entity.ToTable(TableName, SchemaName);

        entity.HasKey(analysedSample => analysedSample.Id);

        entity.Property(analysedSample => analysedSample.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(analysedSample => analysedSample.AnalysisId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(analysedSample => analysedSample.TargetSampleId)
              .HasColumnName(TargetSampleColumnName)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(analysedSample => analysedSample.MatchedSampleId)
              .HasColumnName(MatchedSampleColumnName)
              .ValueGeneratedNever();
    }
}
