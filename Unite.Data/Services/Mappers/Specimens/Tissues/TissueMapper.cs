using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Tissues;
using Unite.Data.Entities.Specimens.Tissues.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Specimens.Tissues;

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


        entity.HasOne<EnumValue<TissueType>>()
              .WithMany()
              .HasForeignKey(tissue => tissue.TypeId);

        entity.HasOne<EnumValue<TumorType>>()
              .WithMany()
              .HasForeignKey(tissue => tissue.TumorTypeId);

        entity.HasOne(tissue => tissue.Source)
              .WithMany()
              .HasForeignKey(tissue => tissue.SourceId);

        entity.HasOne<Specimen>()
              .WithOne(specimen => specimen.Tissue)
              .HasForeignKey<Tissue>(tissue => tissue.SpecimenId)
              .IsRequired();


        entity.HasIndex(tissue => tissue.ReferenceId);
    }
}
