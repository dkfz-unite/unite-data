using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Xenografts;
using Unite.Data.Entities.Specimens.Xenografts.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Specimens.Xenografts
{
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

            entity.Property(xenograft => xenograft.TissueLocationId)
                  .HasConversion<int>();

            entity.Property(xenograft => xenograft.ImplantTypeId)
                  .HasConversion<int>();

            entity.Property(xenograft => xenograft.TumorGrowthFormId)
                  .HasConversion<int>();


            entity.HasOne<EnumValue<ImplantType>>()
                  .WithMany()
                  .HasForeignKey(xenograft => xenograft.ImplantTypeId);

            entity.HasOne<EnumValue<TissueLocation>>()
                  .WithMany()
                  .HasForeignKey(xenograft => xenograft.TissueLocationId);

            entity.HasOne<EnumValue<TumorGrowthForm>>()
                  .WithMany()
                  .HasForeignKey(xenograft => xenograft.TumorGrowthFormId);


            entity.HasOne<Specimen>()
                  .WithOne(specimen => specimen.Xenograft)
                  .HasForeignKey<Xenograft>(xenograft => xenograft.SpecimenId)
                  .IsRequired();


            entity.HasIndex(xenograft => xenograft.ReferenceId);
        }
    }
}
