using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Omics;
using Unite.Data.Entities.Omics.Analysis.Dna.Sm;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Sm;

/// <summary>
/// SM affected transcript mapper.
/// </summary>
internal class AffectedTranscriptMapper : VariantAffectedFeatureMapper<AffectedTranscript, Variant, Transcript>
{
    public override string TableName => "sm_affected_transcript";


    public override void Configure(EntityTypeBuilder<AffectedTranscript> entity)
    {
        base.Configure(entity);

        entity.HasOne(affectedTranscript => affectedTranscript.Variant)
              .WithMany(variant => variant.AffectedTranscripts)
              .HasForeignKey(affectedTranscript => affectedTranscript.VariantId);
    }
}
