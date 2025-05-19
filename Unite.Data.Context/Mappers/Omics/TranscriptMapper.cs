using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Entities.Omics;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Context.Mappers.Omics;

internal class TranscriptMapper : IEntityTypeConfiguration<Transcript>
{
    public void Configure(EntityTypeBuilder<Transcript> entity)
    {
        entity.ToTable("transcript", DomainDbSchemaNames.Omics);

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


        entity.HasOne<EnumEntity<Chromosome>>()
              .WithMany()
              .HasForeignKey(transcript => transcript.ChromosomeId);

        entity.HasOne(transcript => transcript.Gene)
              .WithMany(gene => gene.Transcripts)
              .HasForeignKey(transcript => transcript.GeneId);
    }
}
