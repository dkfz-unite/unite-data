using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    public static class LocalizationModelBuilder
    {
        public static void BuildLocalizationModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Localization>(entity =>
            {
                entity.ToTable("Localizations");

                entity.HasKey(localization => localization.Id);

                entity.Property(localization => localization.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(localization => localization.Value)
                      .IsRequired()
                      .HasMaxLength(50);


                entity.HasIndex(localization => localization.Value)
                      .IsUnique();
            });
        }
    }
}
