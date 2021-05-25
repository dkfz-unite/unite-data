using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Services.Extensions.Model.Specimens
{
    public static class SpecimenModelBuilder
    {
        public static void BuildSpecimenModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specimen>(entity =>
            {
                entity.ToTable("Specimens");

                entity.HasKey(specimen => specimen.Id);

                entity.Property(specimen => specimen.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(specimen => specimen.ReferenceId)
                      .HasMaxLength(255);


                entity.HasOne(specimen => specimen.Parent)
                      .WithMany(specimen => specimen.Children)
                      .HasForeignKey(specimen => specimen.ParentId);

                entity.HasOne(specimen => specimen.Donor)
                      .WithMany(donor => donor.Specimens)
                      .HasForeignKey(specimen => specimen.DonorId);


                entity.HasIndex(specimen => specimen.ReferenceId);
            });
        }
    }
}
