using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Analysis;
using Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Services.Mappers.Genome.Variants.SV;

/// <summary>
/// SV occurrence mapper.
/// </summary>
internal class VariantEntryMapper : Base.AnalysedSampleEntryMapper<VariantEntry, AnalysedSample, Variant, long>
{
    protected override string TableName => "SvEntries";
    protected override string EntityColumnName => "VariantId";

    public override void Configure(EntityTypeBuilder<VariantEntry> entity)
    {
        base.Configure(entity);

        entity.HasOne(entry => entry.Entity)
              .WithMany(variant => variant.Entries)
              .HasForeignKey(entry => entry.EntityId);

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.SvEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);
    }
}
