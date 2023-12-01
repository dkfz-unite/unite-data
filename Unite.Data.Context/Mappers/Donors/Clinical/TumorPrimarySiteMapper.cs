using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors.Clinical;

namespace Unite.Data.Context.Mappers.Donors.Clinical;

internal class TumorPrimarySiteMapper : IEntityTypeConfiguration<TumorPrimarySite>
{
    public void Configure(EntityTypeBuilder<TumorPrimarySite> entity)
    {
        entity.ToTable("TumorPrimarySites", DomainDbSchemaNames.Donors);

        entity.HasKey(primarySite => primarySite.Id);

        entity.HasAlternateKey(primarySite => primarySite.Value);

        entity.Property(primarySite => primarySite.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(primarySite => primarySite.Value)
              .IsRequired()
              .HasMaxLength(100);
    }
}
