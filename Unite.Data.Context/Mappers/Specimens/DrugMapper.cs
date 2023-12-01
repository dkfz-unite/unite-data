using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Context.Mappers.Specimens;

public class DrugMapper : IEntityTypeConfiguration<Drug>
{
    public void Configure(EntityTypeBuilder<Drug> entity)
    {
        entity.ToTable("Drugs", DomainDbSchemaNames.Specimens);

        entity.HasKey(drug => drug.Id);

        entity.HasAlternateKey(drug => drug.Name);

        entity.Property(drug => drug.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(drug => drug.Name)
              .IsRequired()
              .HasMaxLength(100);
    }
}
