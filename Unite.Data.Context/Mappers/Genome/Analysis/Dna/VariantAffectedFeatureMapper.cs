using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Unite.Data.Entities.Genome;
using Unite.Data.Entities.Genome.Analysis.Dna;

namespace Unite.Data.Context.Mappers.Genome.Analysis.Dna;

/// <summary>
/// Affected feature mapper
/// </summary>
/// <typeparam name="TVariantAffectedFeature">Affected feature type</typeparam>
/// <typeparam name="TVariant">Variant type</typeparam>
/// <typeparam name="TFeature">Feature type</typeparam>
internal abstract class VariantAffectedFeatureMapper<TVariantAffectedFeature, TVariant, TFeature> : IEntityTypeConfiguration<TVariantAffectedFeature>
    where TVariantAffectedFeature : VariantAffectedFeature<TVariant, TFeature>
    where TVariant : Variant
    where TFeature : Feature
{
    protected static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    protected static readonly Expression<Func<Effect[], string>> _serialize = value => JsonSerializer.Serialize<Effect[]>(value, _options);
    protected static readonly Expression<Func<string, Effect[]>> _deserialize = value => JsonSerializer.Deserialize<Effect[]>(value, _options);

    public abstract string TableName { get; }


    public virtual void Configure(EntityTypeBuilder<TVariantAffectedFeature> entity)
    {
        entity.ToTable(TableName, DomainDbSchemaNames.Genome);

        entity.HasKey(affectedFeature => new
        {
            affectedFeature.VariantId,
            affectedFeature.FeatureId
        });

        entity.Property(affectedFeature => affectedFeature.VariantId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(affectedFeature => affectedFeature.FeatureId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(affectedFeature => affectedFeature.Effects)
              .HasConversion(_serialize, _deserialize);


        entity.HasOne(affectedFeature => affectedFeature.Feature)
              .WithMany()
              .HasForeignKey(affectedFeature => affectedFeature.FeatureId);
    }
}
