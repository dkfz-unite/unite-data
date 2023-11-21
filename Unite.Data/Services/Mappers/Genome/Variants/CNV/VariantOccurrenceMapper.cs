using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.CNV;

namespace Unite.Data.Services.Mappers.Genome.Variants.CNV;

/// <summary>
/// CNV occurrence mapper
/// </summary>
internal class VariantOccurrenceMapper : VariantOccurrenceMapper<VariantOccurrence, Variant>
{
    public override string TableName => "CnvOccurrences";

    public override void Configure(EntityTypeBuilder<VariantOccurrence> entity)
    {
        base.Configure(entity);


        entity.HasOne(variantOccurrence => variantOccurrence.Variant)
              .WithMany(variant => variant.Occurrences)
              .HasForeignKey(variantOccurrence => variantOccurrence.VariantId);

        entity.HasOne(variantOccurrence => variantOccurrence.AnalysedSample)
              .WithMany(analysedSample => analysedSample.CopyNumberVariantOccurrences)
              .HasForeignKey(variantOccurrence => variantOccurrence.AnalysedSampleId);
    }
}
