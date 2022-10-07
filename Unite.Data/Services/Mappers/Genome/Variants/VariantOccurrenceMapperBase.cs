using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants;

namespace Unite.Data.Services.Mappers.Genome.Variants;

/// <summary>
/// Variant occurrence mapper
/// </summary>
/// <typeparam name="TVariantOccurrence">Variant occurrence type</typeparam>
/// <typeparam name="TVariant">Variant type</typeparam>
internal abstract class VariantOccurrenceMapperBase<TVariantOccurrence, TVariant> : IEntityTypeConfiguration<TVariantOccurrence>
    where TVariantOccurrence : VariantOccurrenceBase<TVariant>
    where TVariant : VariantBase
{
    public abstract string TableName { get; }


    public virtual void Configure(EntityTypeBuilder<TVariantOccurrence> entity)
    {
        entity.ToTable(TableName, DomainDbSchemaNames.Genome);

        entity.HasKey(variantOccurrence => new
        {
            variantOccurrence.VariantId,
            variantOccurrence.AnalysedSampleId
        });

        entity.Property(variantOccurrence => variantOccurrence.VariantId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(variantOccurrence => variantOccurrence.AnalysedSampleId)
              .IsRequired()
              .ValueGeneratedNever();
    }
}
