using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Services.Mappers.Specimens;

internal class SpecimenMapper : IEntityTypeConfiguration<Specimen>
{
    public void Configure(EntityTypeBuilder<Specimen> entity)
    {
        entity.ToTable("Specimens", DomainDbSchemaNames.Specimens);

        entity.HasKey(specimen => specimen.Id);

        entity.Property(specimen => specimen.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(specimen => specimen.DonorId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Ignore(specimen => specimen.Type);


        entity.HasOne(specimen => specimen.Parent)
              .WithMany(specimen => specimen.Children)
              .HasForeignKey(specimen => specimen.ParentId);

        entity.HasOne(specimen => specimen.Donor)
              .WithMany(donor => donor.Specimens)
              .HasForeignKey(specimen => specimen.DonorId);
    }
}
