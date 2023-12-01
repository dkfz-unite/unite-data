using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Organoids;

namespace Unite.Data.Context.Mappers.Specimens.Organoids;

internal class OrganoidMapper : IEntityTypeConfiguration<Organoid>
{
    public void Configure(EntityTypeBuilder<Organoid> entity)
    {
        entity.ToTable("Organoids", DomainDbSchemaNames.Specimens);

        entity.HasKey(organoid => organoid.SpecimenId);

        entity.Property(organoid => organoid.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(organoid => organoid.ReferenceId)
              .HasMaxLength(255);


        entity.HasOne(organoid => organoid.Specimen)
              .WithOne(specimen => specimen.Organoid)
              .HasForeignKey<Organoid>(organoid => organoid.SpecimenId)
              .IsRequired();


        entity.HasIndex(organoid => organoid.ReferenceId);
    }
}
