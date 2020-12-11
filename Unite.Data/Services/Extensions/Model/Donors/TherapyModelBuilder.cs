using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    public static class TherapyModelBuilder
    {
        public static void BuildTherapyModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Therapy>(entity =>
            {
                entity.ToTable("Therapies");

                entity.HasKey(therapy => therapy.Id);

                entity.Property(therapy => therapy.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(therapy => therapy.Name)
                      .IsRequired()
                      .HasMaxLength(100);


                entity.HasIndex(therapy => therapy.Name)
                      .IsUnique();
            });
        }
    }
}
