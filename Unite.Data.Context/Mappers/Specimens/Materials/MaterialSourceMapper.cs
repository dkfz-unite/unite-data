using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Materials;

namespace Unite.Data.Context.Mappers.Specimens.Materials;

internal class MaterialSourceMapper : IEntityTypeConfiguration<MaterialSource>
{
    public void Configure(EntityTypeBuilder<MaterialSource> entity)
    {
        entity.ToTable("material_source", DomainDbSchemaNames.Specimens);

        entity.HasKey(source => source.Id);

        entity.HasAlternateKey(source => source.Value);

        entity.Property(source => source.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(source => source.Value)
              .IsRequired()
              .HasMaxLength(100);
    }
}
