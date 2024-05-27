using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Analysis;
using Unite.Data.Entities.Images.Analysis.Radiomics;

namespace Unite.Data.Context.Mappers.Images.Analysis.Radiomics;

internal class FeatureEntryMapper : Base.SampleEntryMapper<FeatureEntry, Sample, Feature>
{
    protected override string SchemaName => DomainDbSchemaNames.Images;
    protected override string TableName => "RadiomicsFeatureEntries";
    protected override string EntityColumnName => "FeatureId";

    public override void Configure(EntityTypeBuilder<FeatureEntry> entity)
    {
        base.Configure(entity);

        entity.Property(entry => entry.Value)
              .IsRequired();


        entity.HasOne(entry => entry.Sample)
              .WithMany(sample => sample.RadiomicsFeatureEntries)
              .HasForeignKey(entry => entry.SampleId);

        entity.HasOne(entry => entry.Entity)
              .WithMany(feature => feature.Entries)
              .HasForeignKey(entry => entry.EntityId);
    }
}
