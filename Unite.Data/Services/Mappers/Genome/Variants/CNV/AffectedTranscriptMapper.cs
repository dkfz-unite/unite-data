using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;
using Unite.Data.Entities.Genome.Variants.CNV;

namespace Unite.Data.Services.Mappers.Genome.Variants.CNV;

/// <summary>
/// CNV affected transcript mapper
/// </summary>
internal class AffectedTranscriptMapper : VariantAffectedFeatureMapper<AffectedTranscript, Variant, Transcript>
{
    public override string TableName => "CnvAffectedTranscripts";
    public override string FeatureColumnName => "TranscriptId";


    public override void Configure(EntityTypeBuilder<AffectedTranscript> entity)
    {
        base.Configure(entity);


        entity.HasOne(affectedFeature => affectedFeature.Variant)
              .WithMany(variant => variant.AffectedTranscripts)
              .HasForeignKey(affectedFeature => affectedFeature.VariantId);
    }
}
