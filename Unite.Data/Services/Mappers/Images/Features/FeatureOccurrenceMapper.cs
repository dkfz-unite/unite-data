using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Features;

namespace Unite.Data.Services.Mappers.Images.Features
{
    internal class FeatureOccurrenceMapper : IEntityTypeConfiguration<FeatureOccurrence>
    {
        public void Configure(EntityTypeBuilder<FeatureOccurrence> entity)
        {
            entity.ToTable("FeatureOccurrences", DomainDbSchemaNames.Images);

            entity.HasKey(featureOccurrence => featureOccurrence.Id);

            entity.HasAlternateKey(featureOccurrence => new
            {
                featureOccurrence.FeatureId,
                featureOccurrence.SampleId
            });

            entity.Property(featureOccurrence => featureOccurrence.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(featureOccurrence => featureOccurrence.SampleId)
                  .IsRequired()
                  .ValueGeneratedNever();

            entity.Property(featureOccurrence => featureOccurrence.FeatureId)
                  .IsRequired()
                  .ValueGeneratedNever();

            entity.Property(featureOccurrence => featureOccurrence.Value)
                  .IsRequired();


            entity.HasOne(featureOccurrence => featureOccurrence.Sample)
                  .WithMany(analysedImage => analysedImage.FeatureOccurrences)
                  .HasForeignKey(featureOccurrence => featureOccurrence.SampleId);

            entity.HasOne(featureOccurrence => featureOccurrence.Feature)
                  .WithMany(feature => feature.FeatureOccurrences)
                  .HasForeignKey(featureOccurrence => featureOccurrence.FeatureId);
        }
    }
}
