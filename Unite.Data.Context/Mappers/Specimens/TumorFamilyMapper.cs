using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Context.Mappers.Specimens;

internal class TumorFamilyMapper : IEntityTypeConfiguration<TumorFamily>
{
    public void Configure(EntityTypeBuilder<TumorFamily> entity)
    {
        entity.ToTable("tumor_family", DomainDbSchemaNames.Specimens);

        entity.HasKey(tumorFamily => tumorFamily.Id);

        entity.HasAlternateKey(tumorFamily => tumorFamily.Name);

        entity.Property(tumorFamily => tumorFamily.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(tumorFamily => tumorFamily.Name)
              .IsRequired()
              .HasMaxLength(255);
    }
}
