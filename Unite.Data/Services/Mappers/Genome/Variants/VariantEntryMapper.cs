using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants;

namespace Unite.Data.Services.Mappers.Genome.Variants;

/// <summary>
/// Variant occurrence mapper.
/// </summary>
/// <typeparam name="TVariantEntry">Variant occurrence type.</typeparam>
/// <typeparam name="TVariant">Variant type.</typeparam>
internal abstract class VariantEntryMapper<TVariantEntry, TVariant> : IEntityTypeConfiguration<TVariantEntry>
    where TVariantEntry : VariantEntry<TVariant>
    where TVariant : Variant
{
    public abstract string TableName { get; }


    public virtual void Configure(EntityTypeBuilder<TVariantEntry> entity)
    {
        entity.ToTable(TableName, DomainDbSchemaNames.Genome);

        entity.HasKey(entry => new
        {
            entry.VariantId,
            entry.AnalysedSampleId
        });

        entity.Property(entry => entry.VariantId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(entry => entry.AnalysedSampleId)
              .IsRequired()
              .ValueGeneratedNever();
    }
}
