using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Clinical;

namespace Unite.Data.Services.Extensions.Model.Clinical
{
    public static class LocalizationModelBuilder
    {
        public static void BuildLocalizationModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Localization>(entity =>
            {
                entity.ToTable("Localizations");

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
