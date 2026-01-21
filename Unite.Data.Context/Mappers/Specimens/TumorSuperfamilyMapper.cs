using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Context.Mappers.Specimens;

internal class TumorSuperfamilyMapper : IEntityTypeConfiguration<TumorSuperfamily>
{
    public void Configure(EntityTypeBuilder<TumorSuperfamily> entity)
    {
        entity.ToTable("tumor_superfamily", DomainDbSchemaNames.Specimens);

        entity.HasKey(tumorSuperfamily => tumorSuperfamily.Id);

        entity.HasAlternateKey(tumorSuperfamily => tumorSuperfamily.Name);

        entity.Property(tumorSuperfamily => tumorSuperfamily.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(tumorSuperfamily => tumorSuperfamily.Name)
              .IsRequired()
              .HasMaxLength(255);
    }
}
