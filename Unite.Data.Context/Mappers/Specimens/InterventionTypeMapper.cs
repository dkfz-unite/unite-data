using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Context.Mappers.Specimens;

internal class InterventionTypeMapper : IEntityTypeConfiguration<InterventionType>
{
    public void Configure(EntityTypeBuilder<InterventionType> entity)
    {
        entity.ToTable("intervention_type", DomainDbSchemaNames.Specimens);

        entity.HasKey(interventionType => interventionType.Id);

        entity.HasAlternateKey(interventionType => interventionType.Name);

        entity.Property(interventionType => interventionType.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(interventionType => interventionType.Name)
              .IsRequired()
              .HasMaxLength(100);
    }
}
