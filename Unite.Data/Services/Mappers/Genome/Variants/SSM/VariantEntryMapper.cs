using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.SSM;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Genome.Variants.SSM;

/// <summary>
/// SSM entries mapper
/// </summary>
internal class VariantEntryMapper : AnalysisFeatureEntryMapper<VariantEntry, Variant>
{
    public override string TableName => "SsmEntries";
    public override string SchemaName => DomainDbSchemaNames.Genome;

    public override string FeatureColumnName => "VariantId";
    public override string AnalysedSampleColumnName => "AnalysedSampleId";


    public override void Configure(EntityTypeBuilder<VariantEntry> entity)
    {
        base.Configure(entity);


        entity.HasOne(entry => entry.Feature)
              .WithMany(feature => feature.Entries)
              .HasForeignKey(entry => entry.FeatureId);

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.SsmEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);
    }
}
