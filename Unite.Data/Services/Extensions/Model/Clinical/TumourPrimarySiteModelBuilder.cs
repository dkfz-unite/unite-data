using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Clinical;

namespace Unite.Data.Services.Extensions.Model.Clinical
{
    public static class TumourPrimarySiteModelBuilder
    {
        public static void TumourBuildPrimarySiteModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TumourPrimarySite>(entity =>
            {
                entity.ToTable("TumourPrimarySites");

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
