using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations;

namespace Unite.Data.Services.Mappers.Genome.Mutations;

internal class AffectedTranscriptConsequenceMapper : IEntityTypeConfiguration<AffectedTranscriptConsequence>
{
    public void Configure(EntityTypeBuilder<AffectedTranscriptConsequence> entity)
    {
        entity.ToTable("AffectedTranscriptConsequences", DomainDbSchemaNames.Genome);

        entity.HasKey(affectedTranscriptConsequence => new
        {
            affectedTranscriptConsequence.AffectedTranscriptId,
            affectedTranscriptConsequence.ConsequenceId
        });

        entity.Property(affectedTranscriptConsequence => affectedTranscriptConsequence.AffectedTranscriptId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(affectedTranscriptConsequence => affectedTranscriptConsequence.ConsequenceId)
              .IsRequired()
              .HasConversion<int>()
              .ValueGeneratedNever();


        entity.HasOne(affectedTranscriptConsequence => affectedTranscriptConsequence.AffectedTranscript)
              .WithMany(affectedTranscript => affectedTranscript.Consequences)
              .HasForeignKey(affectedTranscriptConsequence => affectedTranscriptConsequence.AffectedTranscriptId);

        entity.HasOne(affectedTranscriptConsequence => affectedTranscriptConsequence.Consequence)
              .WithMany()
              .HasForeignKey(affectedTranscriptConsequence => affectedTranscriptConsequence.ConsequenceId);
    }
}
