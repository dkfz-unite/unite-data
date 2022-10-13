using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Services.Mappers.Genome.Variants.SV;

/// <summary>
/// SV occurrence mapper
/// </summary>
internal class VariantOccurrenceMapper : VariantOccurrenceMapper<VariantOccurrence, Variant>
{
    public override string TableName => "SvOccurrences";

    public override void Configure(EntityTypeBuilder<VariantOccurrence> entity)
    {
        base.Configure(entity);


        entity.HasOne(variantOccurrence => variantOccurrence.Variant)
              .WithMany(variant => variant.Occurrences)
              .HasForeignKey(variantOccurrence => variantOccurrence.VariantId);

        entity.HasOne(variantOccurrence => variantOccurrence.AnalysedSample)
              .WithMany(analysedSample => analysedSample.StructuralVariantOccurrences)
              .HasForeignKey(variantOccurrence => variantOccurrence.AnalysedSampleId);
    }
}
