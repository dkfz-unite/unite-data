using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Features;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Images.Features;

internal class RadiomicsFeatureEntryMapper : AnalysisEntityEntryMapper<RadiomicsFeatureEntry, RadiomicsFeature, int>
{
    public override string TableName => "RadiomicsFeatureEntries";
    public override string SchemaName => DomainDbSchemaNames.Images;

    public override void Configure(EntityTypeBuilder<RadiomicsFeatureEntry> entity)
    {
        base.Configure(entity);

        entity.Property(entry => entry.Value)
              .IsRequired();

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.RadiomicsFeatureEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);

        entity.HasOne(entry => entry.Entity)
              .WithMany(feature => feature.Entries)
              .HasForeignKey(entry => entry.EntityId);
    }
}
