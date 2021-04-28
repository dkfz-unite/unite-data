using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    public static class PseudonymModelBuilder
    {
        public static void BuildPseudonymModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pseudonym>(entity =>
            {
                entity.ToTable("Pseudonyms");

                entity.HasKey(pseudonym => pseudonym.Name);

                entity.Property(pseudonym => pseudonym.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(pseudonym => pseudonym.DonorId)
                      .IsRequired();


                entity.HasOne<Donor>()
                      .WithMany(donor => donor.Pseudonyms)
                      .HasForeignKey(pseudonym => pseudonym.DonorId);
            });
        }
    }
}
