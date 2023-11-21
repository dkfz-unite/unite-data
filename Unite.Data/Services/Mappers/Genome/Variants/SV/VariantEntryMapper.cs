using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Services.Mappers.Genome.Variants.SV;

/// <summary>
/// SV occurrence mapper.
/// </summary>
internal class VariantEntryMapper : VariantEntryMapper<VariantEntry, Variant>
{
    public override string TableName => "SvEntries";

    public override void Configure(EntityTypeBuilder<VariantEntry> entity)
    {
        base.Configure(entity);


        entity.HasOne(entry => entry.Variant)
              .WithMany(variant => variant.Entries)
              .HasForeignKey(entry => entry.VariantId);

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.SvEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);
    }
}
