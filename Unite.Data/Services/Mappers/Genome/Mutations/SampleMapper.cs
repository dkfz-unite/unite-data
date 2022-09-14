using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations;

namespace Unite.Data.Services.Mappers.Genome.Mutations;

public class SampleMapper : IEntityTypeConfiguration<Sample>
{
    public void Configure(EntityTypeBuilder<Sample> entity)
    {
        entity.ToTable("Samples", DomainDbSchemaNames.Genome);

        entity.HasKey(sample => sample.Id);

        entity.Property(sample => sample.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(sample => sample.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(sample => sample.ReferenceId)
              .HasMaxLength(255);


        entity.HasOne(sample => sample.Specimen)
              .WithMany(specimen => specimen.Samples)
              .HasForeignKey(sample => sample.SpecimenId);


        entity.HasIndex(sample => sample.ReferenceId);
    }
}
