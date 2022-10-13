using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;
using Unite.Data.Entities.Genome.Variants.SSM;

namespace Unite.Data.Services.Mappers.Genome.Variants.SSM;

/// <summary>
/// SSM affected transcript mapper
/// </summary>
internal class AffectedTranscriptMapper : VariantAffectedFeatureMapper<AffectedTranscript, Variant, Transcript>
{
    public override string TableName => "SsmAffectedTranscripts";


    public override void Configure(EntityTypeBuilder<AffectedTranscript> entity)
    {
        base.Configure(entity);


        entity.HasOne(affectedTranscript => affectedTranscript.Variant)
              .WithMany(variant => variant.AffectedTranscripts)
              .HasForeignKey(affectedTranscript => affectedTranscript.VariantId);
    }
}
