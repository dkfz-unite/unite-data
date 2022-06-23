using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Donors.Clinical;

namespace Unite.Data.Services.Mappers.Donors.Clinical;

internal class TreatmentMapper : IEntityTypeConfiguration<Treatment>
{
    public void Configure(EntityTypeBuilder<Treatment> entity)
    {
        entity.ToTable("Treatments", DomainDbSchemaNames.Donors);

        entity.HasKey(treatment => treatment.Id);

        entity.Property(treatment => treatment.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(treatment => treatment.DonorId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(treatment => treatment.TherapyId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne<Donor>()
              .WithMany(donor => donor.Treatments)
              .HasForeignKey(treatment => treatment.DonorId);

        entity.HasOne(treatment => treatment.Therapy)
              .WithMany()
              .HasForeignKey(treatment => treatment.TherapyId);
    }
}
