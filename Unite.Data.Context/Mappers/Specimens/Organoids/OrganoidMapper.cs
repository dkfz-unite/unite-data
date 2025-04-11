using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Organoids;

namespace Unite.Data.Context.Mappers.Specimens.Organoids;

internal class OrganoidMapper : IEntityTypeConfiguration<Organoid>
{
    public void Configure(EntityTypeBuilder<Organoid> entity)
    {
        entity.ToTable("organoid", DomainDbSchemaNames.Specimens);

        entity.HasKey(organoid => organoid.SpecimenId);

        entity.Property(organoid => organoid.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(organoid => organoid.Specimen)
              .WithOne(specimen => specimen.Organoid)
              .HasForeignKey<Organoid>(organoid => organoid.SpecimenId)
              .IsRequired();
    }
}
