using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Omics.Analysis;

namespace Unite.Data.Context.Mappers.Omics.Analysis;

internal class SampleMapper : Base.SampleMapper<Sample>
{
    protected override string SchemaName => DomainDbSchemaNames.Omics;

    public override void Configure(EntityTypeBuilder<Sample> entity)
    {
        base.Configure(entity);

        entity.HasOne(sample => sample.Specimen)
              .WithMany(specimen => specimen.OmicsSamples)
              .HasForeignKey(sample => sample.SpecimenId);

        entity.HasOne(sample => sample.Analysis)
              .WithOne(analysis => analysis.Sample)
              .HasForeignKey<Sample>(sample => sample.AnalysisId);

        entity.HasOne(sample => sample.MatchedSample)
              .WithMany()
              .HasForeignKey(sample => sample.MatchedSampleId);
    }
}
