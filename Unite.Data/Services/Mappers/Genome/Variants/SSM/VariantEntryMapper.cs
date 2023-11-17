using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.SSM;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Genome.Variants.SSM;

/// <summary>
/// SSM entries mapper
/// </summary>
internal class VariantEntryMapper : AnalysisEntityEntryMapper<VariantEntry, Variant, long>
{
    public override string TableName => "SsmEntries";
    public override string SchemaName => DomainDbSchemaNames.Genome;

    public override string EntityColumnName => "VariantId";
    public override string AnalysedSampleColumnName => "AnalysedSampleId";


    public override void Configure(EntityTypeBuilder<VariantEntry> entity)
    {
        base.Configure(entity);


        entity.HasOne(entry => entry.Entity)
              .WithMany(feature => feature.Entries)
              .HasForeignKey(entry => entry.EntityId);

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.SsmEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);
    }
}
