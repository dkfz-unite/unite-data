using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Radiology;

namespace Unite.Data.Services.Mappers.Radiology
{
    internal class ImageFeatureOccurrenceMapper : IEntityTypeConfiguration<ImageFeatureOccurrence>
    {
        public void Configure(EntityTypeBuilder<ImageFeatureOccurrence> entity)
        {
            entity.ToTable("ImageFeatureOccurrences", DomainDbSchemaNames.Radiology);

            entity.HasKey(featureOccurrence => featureOccurrence.Id);

            entity.Property(featureOccurrence => featureOccurrence.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(featureOccurrence => featureOccurrence.AnalysedImageId)
                  .IsRequired()
                  .ValueGeneratedNever();

            entity.Property(featureOccurrence => featureOccurrence.FeatureId)
                  .IsRequired()
                  .ValueGeneratedNever();

            entity.Property(featureOccurrence => featureOccurrence.Value)
                  .IsRequired();


            entity.HasOne(featureOccurrence => featureOccurrence.AnalysedImage)
                  .WithMany(analysedImage => analysedImage.FeatureOccurrences)
                  .HasForeignKey(featureOccurrence => featureOccurrence.AnalysedImageId);

            entity.HasOne(featureOccurrence => featureOccurrence.Feature)
                  .WithMany(feature => feature.FeatureOccurrences)
                  .HasForeignKey(featureOccurrence => featureOccurrence.FeatureId);
        }
    }
}
