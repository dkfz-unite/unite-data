using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Radiology;

namespace Unite.Data.Services.Mappers.Radiology
{
    internal class ImageFeatureMapper : IEntityTypeConfiguration<ImageFeature>
    {
        public void Configure(EntityTypeBuilder<ImageFeature> entity)
        {
            entity.ToTable("ImageFeatures", DomainDbSchemaNames.Radiology);

            entity.HasKey(feature => feature.Id);

            entity.Property(feature => feature.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(feature => feature.Name)
                  .IsRequired()
                  .HasMaxLength(255);
        }
    }
}
