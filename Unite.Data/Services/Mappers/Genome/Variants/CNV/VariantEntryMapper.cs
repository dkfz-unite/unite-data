using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Analysis;
using Unite.Data.Entities.Genome.Variants.CNV;

namespace Unite.Data.Services.Mappers.Genome.Variants.CNV;

/// <summary>
/// CNV occurrence mapper.
/// </summary>
internal class VariantEntryMapper : Base.AnalysedSampleEntryMapper<VariantEntry, AnalysedSample, Variant, long>
{
    protected override string TableName => "CnvEntries";
    protected override string EntityColumnName => "VariantId";

    public override void Configure(EntityTypeBuilder<VariantEntry> entity)
    {
        base.Configure(entity);

        entity.HasOne(entry => entry.Entity)
              .WithMany(variant => variant.Entries)
              .HasForeignKey(entry => entry.EntityId);

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.CnvEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);
    }
}
