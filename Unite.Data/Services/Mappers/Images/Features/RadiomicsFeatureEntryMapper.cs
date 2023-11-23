using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Analysis;
using Unite.Data.Entities.Images.Features;

namespace Unite.Data.Services.Mappers.Images.Features;

internal class RadiomicsFeatureEntryMapper : Base.AnalysedSampleEntryMapper<RadiomicsFeatureEntry, AnalysedSample, RadiomicsFeature, int>
{
    protected override string TableName => "RadiomicsFeatureEntries";
    protected override string EntityColumnName => "FeatureId";

    public override void Configure(EntityTypeBuilder<RadiomicsFeatureEntry> entity)
    {
        base.Configure(entity);

        entity.Property(entry => entry.Value)
              .IsRequired();


        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedImage => analysedImage.RadiomicsFeatureEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);

        entity.HasOne(entry => entry.Entity)
              .WithMany(feature => feature.Entries)
              .HasForeignKey(entry => entry.EntityId);
    }
}
