using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.SSM;

namespace Unite.Data.Services.Mappers.Genome.Variants.SSM;

/// <summary>
/// SSM occurrence mapper
/// </summary>
internal class VariantOccurrenceMapper : VariantOccurrenceMapperBase<VariantOccurrence, Variant>
{
    public override string TableName => "SsmOccurrences";


    public override void Configure(EntityTypeBuilder<VariantOccurrence> entity)
    {
        base.Configure(entity);


        entity.HasOne(variantOccurrence => variantOccurrence.Variant)
              .WithMany(variant => variant.Occurrences)
              .HasForeignKey(variantOccurrence => variantOccurrence.VariantId);

        entity.HasOne(variantOccurrence => variantOccurrence.AnalysedSample)
              .WithMany(analysedSample => analysedSample.MutationOccurrences)
              .HasForeignKey(variantOccurrence => variantOccurrence.AnalysedSampleId);
    }
}
