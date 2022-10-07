using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants;

namespace Unite.Data.Services.Mappers.Genome.Variants;

/// <summary>
/// Affected transcript mapper
/// </summary>
/// <typeparam name="TAffectedTranscript">Affected transcript type</typeparam>
/// <typeparam name="TVariant">Variant type</typeparam>
internal abstract class AffectedTranscriptMapperBase<TAffectedTranscript, TVariant> : IEntityTypeConfiguration<TAffectedTranscript>
    where TAffectedTranscript : AffectedTranscriptBase<TVariant>
    where TVariant : VariantBase
{
    protected static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    protected static readonly Expression<Func<Consequence[], string>> _serialize = value => JsonSerializer.Serialize<Consequence[]>(value, _options);
    protected static readonly Expression<Func<string, Consequence[]>> _deserialize = value => JsonSerializer.Deserialize<Consequence[]>(value, _options);

    public abstract string TableName { get; }


    public virtual void Configure(EntityTypeBuilder<TAffectedTranscript> entity)
    {
        entity.ToTable(TableName, DomainDbSchemaNames.Genome);

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

        entity.Property(affectedTranscript => affectedTranscript.Consequences)
              .HasConversion(_serialize, _deserialize);


        entity.HasOne(affectedTranscript => affectedTranscript.Transcript)
              .WithMany()
              .HasForeignKey(affectedTranscript => affectedTranscript.TranscriptId);
    }
}
