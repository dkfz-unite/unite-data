using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unite.Data.Services.Mappers.Base;

internal abstract class AnalysedSampleMapper<TAnalysedSample> : IEntityTypeConfiguration<TAnalysedSample>
    where TAnalysedSample : Entities.Base.AnalysedSample
{
    public abstract string TableName { get; }
    public abstract string SchemaName { get; }


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
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(analysedSample => analysedSample.MatchedSampleId)
              .ValueGeneratedNever();

        entity.Property(analysedSample => analysedSample.ReferenceId)
              .HasMaxLength(255);
    }
}
