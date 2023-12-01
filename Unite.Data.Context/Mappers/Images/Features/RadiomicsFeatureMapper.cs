using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Features;

namespace Unite.Data.Context.Mappers.Images.Features;

internal class RadiomicsFeatureMapper : IEntityTypeConfiguration<RadiomicsFeature>
{
    public void Configure(EntityTypeBuilder<RadiomicsFeature> entity)
    {
        entity.ToTable("RadiomicsFeatures", DomainDbSchemaNames.Images);

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
