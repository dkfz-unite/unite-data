using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    public static class DonorModelBuilder
    {
        public static void BuildDonorModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donor>(entity =>
            {
                entity.ToTable("Donors");

                entity.HasKey(donor => donor.Id);

                entity.Property(donor => donor.Id)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(donor => donor.Diagnosis)
                      .HasMaxLength(100);

                entity.Property(donor => donor.Origin)
                      .HasMaxLength(100);


                entity.HasOne(donor => donor.PrimarySite)
                      .WithMany()
                      .HasForeignKey(donor => donor.PrimarySiteId);
            });
        }
    }
}
