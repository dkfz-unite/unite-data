using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images;

namespace Unite.Data.Services.Mappers.Images
{
    internal class ImageFeatureMapper : IEntityTypeConfiguration<ImageFeature>
    {
        public void Configure(EntityTypeBuilder<ImageFeature> entity)
        {
            entity.ToTable("ImageFeatures", DomainDbSchemaNames.Images);

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
