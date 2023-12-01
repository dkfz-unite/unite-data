using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Specimens.Tissues;
using Unite.Data.Entities.Specimens.Tissues.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Tissues;

internal class TissueMapper : IEntityTypeConfiguration<Tissue>
{
    public void Configure(EntityTypeBuilder<Tissue> entity)
    {
        entity.ToTable("Tissues", DomainDbSchemaNames.Specimens);

        entity.HasKey(tissue => tissue.SpecimenId);

        entity.Property(tissue => tissue.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(tissue => tissue.ReferenceId)
              .HasMaxLength(255);

        entity.Property(tissue => tissue.TypeId)
              .HasConversion<int>();

        entity.Property(tissue => tissue.TumorTypeId)
              .HasConversion<int>();


        entity.HasOne<EnumEntity<TissueType>>()
              .WithMany()
              .HasForeignKey(tissue => tissue.TypeId);

        entity.HasOne<EnumEntity<TumorType>>()
              .WithMany()
              .HasForeignKey(tissue => tissue.TumorTypeId);

        entity.HasOne(tissue => tissue.Source)
              .WithMany()
              .HasForeignKey(tissue => tissue.SourceId);

        entity.HasOne(tissue => tissue.Specimen)
              .WithOne(specimen => specimen.Tissue)
              .HasForeignKey<Tissue>(tissue => tissue.SpecimenId)
              .IsRequired();


        entity.HasIndex(tissue => tissue.ReferenceId);
    }
}
