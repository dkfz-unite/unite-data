using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Features;

namespace Unite.Data.Services.Mappers.Images.Features;

internal class FeatureMapper : IEntityTypeConfiguration<RadiomicsFeature>
{
    public void Configure(EntityTypeBuilder<RadiomicsFeature> entity)
    {
        entity.ToTable("Features", DomainDbSchemaNames.Images);

        entity.HasKey(feature => feature.Id);

        entity.HasAlternateKey(feature => feature.Name);

        entity.Property(feature => feature.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(feature => feature.Name)
              .IsRequired()
              .HasMaxLength(255);
    }
}
