using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors.Clinical;

namespace Unite.Data.Context.Mappers.Donors.Clinical;

internal class TumorLocalizationMapper : IEntityTypeConfiguration<TumorLocalization>
{
    public void Configure(EntityTypeBuilder<TumorLocalization> entity)
    {
        entity.ToTable("TumorLocalizations", DomainDbSchemaNames.Donors);

        entity.HasKey(localization => localization.Id);

        entity.HasAlternateKey(localization => localization.Value);

        entity.Property(localization => localization.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(localization => localization.Value)
              .IsRequired()
              .HasMaxLength(100);
    }
}
