using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Clinical;

namespace Unite.Data.Services.Extensions.Model.Clinical
{
    internal static class TumorLocalizationModelBuilder
    {
        internal static void BuildTumorLocalizationModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TumorLocalization>(entity =>
            {
                entity.ToTable("TumorLocalizations");

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
