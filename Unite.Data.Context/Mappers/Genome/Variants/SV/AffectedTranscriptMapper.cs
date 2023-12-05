using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;
using Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Context.Mappers.Genome.Variants.SV;

/// <summary>
/// SV affected transcript mapper
/// </summary>
internal class AffectedTranscriptMapper : VariantAffectedFeatureMapper<AffectedTranscript, Variant, Transcript>
{
    public override string TableName => "SvAffectedTranscripts";

    public override void Configure(EntityTypeBuilder<AffectedTranscript> entity)
    {
        base.Configure(entity);


        entity.HasOne(affectedTranscript => affectedTranscript.Variant)
              .WithMany(variant => variant.AffectedTranscripts)
              .HasForeignKey(affectedTranscript => affectedTranscript.VariantId);
    }
}
