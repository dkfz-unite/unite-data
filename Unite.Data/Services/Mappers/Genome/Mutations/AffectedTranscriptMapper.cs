using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations;

namespace Unite.Data.Services.Mappers.Genome.Mutations;

internal class AffectedTranscriptMapper : IEntityTypeConfiguration<AffectedTranscript>
{
    public void Configure(EntityTypeBuilder<AffectedTranscript> entity)
    {
        entity.ToTable("AffectedTranscripts", DomainDbSchemaNames.Genome);

        entity.HasKey(affectedTranscript => affectedTranscript.Id);

        entity.HasAlternateKey(affectedTranscript => new
        {
            affectedTranscript.MutationId,
            affectedTranscript.TranscriptId
        });

        entity.Property(affectedTranscript => affectedTranscript.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(affectedTranscript => affectedTranscript.MutationId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(affectedTranscript => affectedTranscript.TranscriptId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(affectedTranscript => affectedTranscript.Mutation)
              .WithMany(mutation => mutation.AffectedTranscripts)
              .HasForeignKey(affectedTranscript => affectedTranscript.MutationId);

        entity.HasOne(affectedTranscript => affectedTranscript.Transcript)
              .WithMany()
              .HasForeignKey(affectedTranscript => affectedTranscript.TranscriptId);
    }
}
