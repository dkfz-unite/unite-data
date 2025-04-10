using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors.Clinical;

namespace Unite.Data.Context.Mappers.Donors.Clinical;

internal class TherapyMapper : IEntityTypeConfiguration<Therapy>
{
    public void Configure(EntityTypeBuilder<Therapy> entity)
    {
        entity.ToTable("therapy", DomainDbSchemaNames.Donors);

        entity.HasKey(therapy => therapy.Id);

        entity.HasAlternateKey(therapy => therapy.Name);

        entity.Property(therapy => therapy.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(therapy => therapy.Name)
              .IsRequired()
              .HasMaxLength(100);
    }
}
