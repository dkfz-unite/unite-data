using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Features;

namespace Unite.Data.Services.Mappers.Images.Features;

internal class RadiomicsFeatureEntryMapper : IEntityTypeConfiguration<RadiomicsFeatureEntry>
{
    public void Configure(EntityTypeBuilder<RadiomicsFeatureEntry> entity)
    {
        entity.ToTable("RadiomicsFeatureEntries", DomainDbSchemaNames.Images);

        entity.HasKey(entry => new
        {
            entry.FeatureId,
            entry.AnalysedImageId
        });

        entity.Property(entry => entry.AnalysedImageId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(entry => entry.FeatureId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(entry => entry.Value)
              .IsRequired();


        entity.HasOne(entry => entry.AnalysedImage)
              .WithMany(analysedImage => analysedImage.RadiomicsFeatureEntries)
              .HasForeignKey(entry => entry.AnalysedImageId);

        entity.HasOne(entry => entry.Feature)
              .WithMany(feature => feature.Entries)
              .HasForeignKey(entry => entry.FeatureId);
    }
}
