using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors.Clinical;

namespace Unite.Data.Services.Extensions.Model.Donors.Clinical
{
    internal static class TherapyModelBuilder
    {
        internal static void BuildTherapyModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Therapy>(entity =>
            {
                entity.ToTable("Therapies");

                entity.HasKey(therapy => therapy.Id);

                entity.HasAlternateKey(therapy => therapy.Name);

                entity.Property(therapy => therapy.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(therapy => therapy.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }
    }
}
