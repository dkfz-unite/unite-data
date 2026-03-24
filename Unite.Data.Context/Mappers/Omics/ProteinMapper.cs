using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Entities.Omics;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Context.Mappers.Omics;

internal class ProteinMapper : IEntityTypeConfiguration<Protein>
{
    public void Configure(EntityTypeBuilder<Protein> entity)
    {
        entity.ToTable("protein", DomainDbSchemaNames.Omics);

        entity.HasKey(protein => protein.Id);

        entity.HasAlternateKey(protein => protein.StableId);

        entity.Property(protein => protein.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(protein => protein.StableId)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(protein => protein.AccessionId)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(protein => protein.ChromosomeId)
              .HasConversion<int>();

        entity.Property(protein => protein.ChromosomeArmId)
              .HasConversion<int>();


        entity.HasOne<EnumEntity<Chromosome>>()
              .WithMany()
              .HasForeignKey(gene => gene.ChromosomeId);

        entity.HasOne<EnumEntity<ChromosomeArm>>()
              .WithMany()
              .HasForeignKey(gene => gene.ChromosomeArmId);

        entity.HasOne(protein => protein.Transcript)
              .WithOne(transcript => transcript.Protein)
              .HasForeignKey<Protein>(protein => protein.TranscriptId);
    }
}
