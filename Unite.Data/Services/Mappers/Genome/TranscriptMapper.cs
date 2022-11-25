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

        entity.Property(transcript => transcript.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(transcript => transcript.ChromosomeId)
              .HasConversion<int>();

        entity.Property(transcript => transcript.Biotype)
              .HasMaxLength(100);


        entity.HasOne<EnumValue<Chromosome>>()
              .WithMany()
              .HasForeignKey(transcript => transcript.ChromosomeId);

        entity.HasOne(transcript => transcript.Gene)
              .WithMany()
              .HasForeignKey(transcript => transcript.GeneId);

        entity.HasOne(transcript => transcript.Protein)
              .WithMany()
              .HasForeignKey(transcript => transcript.ProteinId);
    }
}
