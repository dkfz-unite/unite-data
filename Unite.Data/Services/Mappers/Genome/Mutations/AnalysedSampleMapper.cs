using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations;

namespace Unite.Data.Services.Mappers.Genome.Mutations;

internal class AnalysedSampleMapper : IEntityTypeConfiguration<AnalysedSample>
{
    public void Configure(EntityTypeBuilder<AnalysedSample> entity)
    {
        entity.ToTable("AnalysedSamples", DomainDbSchemaNames.Genome);

        entity.HasKey(analysedSample => analysedSample.Id);

        entity.Property(analysedSample => analysedSample.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(analysedSample => analysedSample.AnalysisId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(analysedSample => analysedSample.SampleId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(analysedSample => analysedSample.MatchedSampleId)
              .ValueGeneratedNever();


        entity.HasOne(analysedSample => analysedSample.Analysis)
              .WithMany(analysis => analysis.AnalysedSamples)
              .HasForeignKey(analysedSample => analysedSample.AnalysisId);

        entity.HasOne(analysedSample => analysedSample.Sample)
              .WithMany(sample => sample.SampleAnalises)
              .HasForeignKey(analysedSample => analysedSample.SampleId);

        entity.HasOne(analysedSample => analysedSample.MatchedSample)
              .WithMany()
              .HasForeignKey(analysedSample => analysedSample.MatchedSampleId);
    }
}
