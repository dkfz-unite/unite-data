using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    public static class PrimarySiteModelBuilder
    {
        public static void BuildPrimarySiteModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrimarySite>(entity =>
            {
                entity.ToTable("PrimarySites");

                entity.HasKey(primarySite => primarySite.Id);

                entity.Property(primarySite => primarySite.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(primarySite => primarySite.Value)
                      .IsRequired()
                      .HasMaxLength(50);


                entity.HasIndex(primarySite => primarySite.Value)
                      .IsUnique();
            });
        }
    }
}
