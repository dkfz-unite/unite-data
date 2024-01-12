using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Specimens.Xenografts;
using Unite.Data.Entities.Specimens.Xenografts.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Xenografts;

internal class XenograftMapper : IEntityTypeConfiguration<Xenograft>
{
    public void Configure(EntityTypeBuilder<Xenograft> entity)
    {
        entity.ToTable("Xenografts", DomainDbSchemaNames.Specimens);

        entity.HasKey(xenograft => xenograft.SpecimenId);

        entity.Property(xenograft => xenograft.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(xenograft => xenograft.ReferenceId)
              .HasMaxLength(255);

        entity.Property(xenograft => xenograft.ImplantTypeId)
              .HasConversion<int>();

        entity.Property(xenograft => xenograft.ImplantLocationId)
              .HasConversion<int>();

        entity.Property(xenograft => xenograft.ImplantTypeId)
              .HasConversion<int>();

        entity.Property(xenograft => xenograft.TumorGrowthFormId)
              .HasConversion<int>();


        entity.HasOne<EnumEntity<ImplantType>>()
              .WithMany()
              .HasForeignKey(xenograft => xenograft.ImplantTypeId);

        entity.HasOne<EnumEntity<ImplantLocation>>()
              .WithMany()
              .HasForeignKey(xenograft => xenograft.ImplantLocationId);

        entity.HasOne<EnumEntity<TumorGrowthForm>>()
              .WithMany()
              .HasForeignKey(xenograft => xenograft.TumorGrowthFormId);


        entity.HasOne(xenograft => xenograft.Specimen)
              .WithOne(specimen => specimen.Xenograft)
              .HasForeignKey<Xenograft>(xenograft => xenograft.SpecimenId)
              .IsRequired();


        entity.HasIndex(xenograft => xenograft.ReferenceId);
    }
}
