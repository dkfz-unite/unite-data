using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;

namespace Unite.Data.Context.Mappers.Genome;

internal class ProteinMapper : IEntityTypeConfiguration<Protein>
{
    public void Configure(EntityTypeBuilder<Protein> entity)
    {
        entity.ToTable("Proteins", DomainDbSchemaNames.Genome);

        entity.HasKey(protein => protein.Id);

        entity.HasAlternateKey(protein => protein.StableId);

        entity.Property(protein => protein.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(protein => protein.StableId)
              .IsRequired()
              .HasMaxLength(100);


        entity.HasOne(protein => protein.Transcript)
              .WithOne(transcript => transcript.Protein)
              .HasForeignKey<Protein>(protein => protein.TranscriptId);
    }
}
