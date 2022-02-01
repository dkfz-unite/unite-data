using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Xenografts;

namespace Unite.Data.Services.Mappers.Specimens.Xenografts
{
    internal class InterventionTypeMapper : IEntityTypeConfiguration<InterventionType>
    {
        public void Configure(EntityTypeBuilder<InterventionType> entity)
        {
            entity.ToTable("XenograftInterventionTypes", DomainDbSchemaNames.Specimens);

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
}
