using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Clinical;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Extensions.Model.Clinical
{
    public static class TreatmentModelBuilder
    {
        public static void BuildTreatmentModel(this ModelBuilder modelBuilder)
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
