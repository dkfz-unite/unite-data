using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Entities.Specimens.Materials;
using Unite.Data.Entities.Specimens.Materials.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Materials;

internal class MaterialMapper : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> entity)
    {
        entity.ToTable("material", DomainDbSchemaNames.Specimens);

        entity.HasKey(material => material.SpecimenId);

        entity.Property(material => material.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(material => material.TypeId)
              .HasConversion<int>();

        entity.Property(material => material.TumorTypeId)
              .HasConversion<int>();


        entity.HasOne<EnumEntity<MaterialType>>()
              .WithMany()
              .HasForeignKey(material => material.TypeId);

        entity.HasOne<EnumEntity<FixationType>>()
              .WithMany()
              .HasForeignKey(material => material.FixationTypeId);

        entity.HasOne<EnumEntity<TumorType>>()
              .WithMany()
              .HasForeignKey(material => material.TumorTypeId);

        entity.HasOne(material => material.Source)
              .WithMany()
              .HasForeignKey(material => material.SourceId);

        entity.HasOne(material => material.Specimen)
              .WithOne(specimen => specimen.Material)
              .HasForeignKey<Material>(material => material.SpecimenId)
              .IsRequired();
    }
}
