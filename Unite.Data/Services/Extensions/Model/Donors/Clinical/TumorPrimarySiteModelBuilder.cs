using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors.Clinical;

namespace Unite.Data.Services.Extensions.Model.Donors.Clinical
{
    internal static class TumorPrimarySiteModelBuilder
    {
        internal static void BuildTumorPrimarySiteModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TumorPrimarySite>(entity =>
            {
                entity.ToTable("TumorPrimarySites");

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
