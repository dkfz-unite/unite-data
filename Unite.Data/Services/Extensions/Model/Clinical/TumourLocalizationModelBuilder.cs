using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Clinical;

namespace Unite.Data.Services.Extensions.Model.Clinical
{
    public static class TumourLocalizationModelBuilder
    {
        public static void TumourBuildLocalizationModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TumourLocalization>(entity =>
            {
                entity.ToTable("TumourLocalizations");

                entity.HasKey(localization => localization.Id);

                entity.HasAlternateKey(localization => localization.Value);

                entity.Property(localization => localization.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(localization => localization.Value)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }
    }
}
