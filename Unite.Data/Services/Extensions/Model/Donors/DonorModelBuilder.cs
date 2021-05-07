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
                      .ValueGeneratedOnAdd();

                entity.Property(donor => donor.ReferenceId)
                      .HasMaxLength(255);


                entity.HasIndex(donor => donor.ReferenceId);
            });
        }
    }
}
