using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.SSM;

using Consequence = Unite.Data.Entities.Genome.Variants.SSM.AffectedTranscriptConsequence;

namespace Unite.Data.Services.Mappers.Genome.Variants.SSM;

internal class AffectedTranscriptMapper : IEntityTypeConfiguration<AffectedTranscript>
{
    private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    private static readonly Expression<Func<Consequence[], string>> _serialize = value => JsonSerializer.Serialize<Consequence[]>(value, _options);
    private static readonly Expression<Func<string, Consequence[]>> _deserialize = value => JsonSerializer.Deserialize<Consequence[]>(value, _options);

    public void Configure(EntityTypeBuilder<AffectedTranscript> entity)
    {
        entity.ToTable("SSMAffectedTranscripts", DomainDbSchemaNames.Genome);

        entity.HasKey(affectedTranscript => new
        {
            affectedTranscript.VariantId,
            affectedTranscript.TranscriptId
        });

        entity.Property(affectedTranscript => affectedTranscript.VariantId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(affectedTranscript => affectedTranscript.TranscriptId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(affectedTranscript => affectedTranscript.Concequences)
              .HasConversion(_serialize, _deserialize);


        entity.HasOne(affectedTranscript => affectedTranscript.Variant)
              .WithMany(mutation => mutation.AffectedTranscripts)
              .HasForeignKey(affectedTranscript => affectedTranscript.VariantId);

        entity.HasOne(affectedTranscript => affectedTranscript.Transcript)
              .WithMany()
              .HasForeignKey(affectedTranscript => affectedTranscript.TranscriptId);
    }
}
