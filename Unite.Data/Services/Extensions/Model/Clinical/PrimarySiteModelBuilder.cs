using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Clinical;

namespace Unite.Data.Services.Extensions.Model.Clinical
{
    public static class PrimarySiteModelBuilder
    {
        public static void BuildPrimarySiteModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrimarySite>(entity =>
            {
                entity.ToTable("PrimarySites");

                entity.HasKey(primarySite => primarySite.Id);

                entity.HasAlternateKey(primarySite => primarySite.Value);

                entity.Property(primarySite => primarySite.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(primarySite => primarySite.Value)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }
    }
}
