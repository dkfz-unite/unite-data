using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.CNV;

namespace Unite.Data.Services.Mappers.Genome.Variants.CNV;

/// <summary>
/// CNV occurrence mapper.
/// </summary>
internal class VariantEntryMapper : VariantEntryMapper<VariantEntry, Variant>
{
    public override string TableName => "CnvEntries";

    public override void Configure(EntityTypeBuilder<VariantEntry> entity)
    {
        base.Configure(entity);


        entity.HasOne(entry => entry.Variant)
              .WithMany(variant => variant.Entries)
              .HasForeignKey(entry => entry.VariantId);

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.CnvEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);
    }
}
