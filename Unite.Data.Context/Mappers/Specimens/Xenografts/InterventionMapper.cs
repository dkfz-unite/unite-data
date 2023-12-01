using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Xenografts;

namespace Unite.Data.Context.Mappers.Specimens.Xenografts;

internal class InterventionMapper : IEntityTypeConfiguration<Intervention>
{
    public void Configure(EntityTypeBuilder<Intervention> entity)
    {
        entity.ToTable("XenograftInterventions", DomainDbSchemaNames.Specimens);

        entity.HasKey(intervention => intervention.Id);

        entity.Property(intervention => intervention.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(intervention => intervention.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(intervention => intervention.TypeId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(intervention => intervention.Xenograft)
              .WithMany(xenograft => xenograft.Interventions)
              .HasForeignKey(intervention => intervention.SpecimenId);

        entity.HasOne(intervention => intervention.Type)
              .WithMany()
              .HasForeignKey(intervention => intervention.TypeId);
    }
}
