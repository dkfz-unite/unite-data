using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Features;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Images.Features;

internal class FeatureEntryMapper : AnalysisFeatureEntryMapper<RadiomicsFeatureEntry, RadiomicsFeature>
{
    public override string TableName => "FeatureEntries";
    public override string SchemaName => DomainDbSchemaNames.Images;

    public override void Configure(EntityTypeBuilder<RadiomicsFeatureEntry> entity)
    {
        base.Configure(entity);

        entity.Property(entry => entry.Value)
              .IsRequired();

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.RadiomicsFeatureEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);

        entity.HasOne(entry => entry.Feature)
              .WithMany(feature => feature.Entries)
              .HasForeignKey(entry => entry.FeatureId);
    }
}
