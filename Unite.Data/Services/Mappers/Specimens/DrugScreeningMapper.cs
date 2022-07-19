using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Services.Mappers.Specimens;

public class DrugScreeningMapper : IEntityTypeConfiguration<DrugScreening>
{
    public void Configure(EntityTypeBuilder<DrugScreening> entity)
    {
        entity.ToTable("DrugScreenings", DomainDbSchemaNames.Specimens);

        entity.HasKey(drugScreening => drugScreening.Id);

        entity.Property(drugScreening => drugScreening.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(drugScreening => drugScreening.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(drugScreening => drugScreening.DrugId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne<Specimen>()
              .WithMany(specimen => specimen.DrugScreenings)
              .HasForeignKey(drugScreening => drugScreening.SpecimenId);

        entity.HasOne(drugScreening => drugScreening.Drug)
              .WithMany()
              .HasForeignKey(drugScreening => drugScreening.DrugId);
    }
}
