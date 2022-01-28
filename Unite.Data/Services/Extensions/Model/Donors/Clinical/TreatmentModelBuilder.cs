using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Donors.Clinical;

namespace Unite.Data.Services.Extensions.Model.Donors.Clinical
{
    internal static class TreatmentModelBuilder
    {
        internal static void BuildTreatmentModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.ToTable("Treatments");

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
            });
        }
    }
}
