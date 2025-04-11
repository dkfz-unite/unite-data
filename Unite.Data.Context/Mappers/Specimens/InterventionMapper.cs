using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Context.Mappers.Specimens;

internal class InterventionMapper : IEntityTypeConfiguration<Intervention>
{
    public void Configure(EntityTypeBuilder<Intervention> entity)
    {
        entity.ToTable("intervention", DomainDbSchemaNames.Specimens);

        entity.HasKey(intervention => new { intervention.TypeId, intervention.SpecimenId });

        entity.Property(intervention => intervention.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(intervention => intervention.TypeId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(intervention => intervention.Specimen)
              .WithMany(specimen => specimen.Interventions)
              .HasForeignKey(intervention => intervention.SpecimenId);

        entity.HasOne(intervention => intervention.Type)
              .WithMany()
              .HasForeignKey(intervention => intervention.TypeId);
    }
}
