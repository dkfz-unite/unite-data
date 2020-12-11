using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    public static class TreatmentModelBuilder
    {
        public static void BuildTreatmentModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.ToTable("Treatments");

                entity.HasKey(treatment => new { treatment.DonorId, treatment.TherapyId });

                entity.Property(treatment => treatment.DonorId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(treatment => treatment.TherapyId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne(treatment => treatment.Donor)
                      .WithMany(donor => donor.Treatments)
                      .HasForeignKey(treatment => treatment.DonorId);

                entity.HasOne(treatment => treatment.Therapy)
                      .WithMany()
                      .HasForeignKey(treatment => treatment.TherapyId);
            });
        }
    }
}
