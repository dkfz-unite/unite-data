using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.CNV;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Genome.Variants.CNV;

/// <summary>
/// CNV entry mapper
/// </summary>
internal class VariantEntryMapper : AnalysisFeatureEntryMapper<VariantEntry, Variant>
{
    public override string TableName => "CnvEntries";
    public override string SchemaName => DomainDbSchemaNames.Genome;

    public override string FeatureColumnName => "VariantId";
    public override string AnalysedSampleColumnName => "AnalysedSampleId";


    public override void Configure(EntityTypeBuilder<VariantEntry> entity)
    {
        entity.HasOne(entry => entry.Feature)
              .WithMany(variant => variant.Entries)
              .HasForeignKey(entry => entry.FeatureId);

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.CnvEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);
    }
}
