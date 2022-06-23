using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Mappers.Donors;

internal class DonorMapper : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> entity)
    {
        entity.ToTable("Donors", DomainDbSchemaNames.Donors);

        entity.HasKey(donor => donor.Id);

        entity.Property(donor => donor.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(donor => donor.ReferenceId)
              .HasMaxLength(255);


        entity.HasIndex(donor => donor.ReferenceId);
    }
}
