using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;
using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Genome;

internal class TranscriptMapper : IEntityTypeConfiguration<Transcript>
{
    public void Configure(EntityTypeBuilder<Transcript> entity)
    {
        entity.ToTable("Transcripts", DomainDbSchemaNames.Genome);

        entity.HasKey(transcript => transcript.Id);

        entity.HasAlternateKey(transcript => transcript.StableId);

        entity.Property(transcript => transcript.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(transcript => transcript.StableId)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(transcript => transcript.ChromosomeId)
              .HasConversion<int>();

        entity.Property(transcript => transcript.Biotype)
              .HasMaxLength(100);


        entity.HasOne<EnumValue<Chromosome>>()
              .WithMany()
              .HasForeignKey(transcript => transcript.ChromosomeId);

        entity.HasOne(transcript => transcript.Gene)
              .WithMany(gene => gene.Transcripts)
              .HasForeignKey(transcript => transcript.GeneId);
    }
}
