using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations;

namespace Unite.Data.Services.Mappers.Genome.Mutations
{
    internal class SampleMapper : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> entity)
        {
            entity.ToTable("Samples", DomainDbSchemaNames.Genome);

            entity.HasKey(sample => sample.Id);

            entity.Property(sample => sample.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(sample => sample.SpecimenId)
                  .IsRequired()
                  .ValueGeneratedNever();

            entity.Property(sample => sample.AnalysisId)
                  .IsRequired()
                  .ValueGeneratedNever();

            entity.Property(sample => sample.MatchedSampleId)
                  .ValueGeneratedNever();


            entity.HasOne(sample => sample.Specimen)
                  .WithMany(specimen => specimen.Samples)
                  .HasForeignKey(sample => sample.SpecimenId);

            entity.HasOne(sample => sample.Analysis)
                  .WithMany(analysis => analysis.Samples)
                  .HasForeignKey(sample => sample.AnalysisId);

            entity.HasOne(sample => sample.MatchedSample)
                  .WithMany()
                  .HasForeignKey(sample => sample.MatchedSampleId);
        }
    }
}
