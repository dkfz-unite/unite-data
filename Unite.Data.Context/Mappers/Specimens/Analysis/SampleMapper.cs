using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Analysis;

namespace Unite.Data.Context.Mappers.Specimens.Analysis;

internal class SampleMapper : Base.SampleMapper<Sample>
{
    protected override string SchemaName => DomainDbSchemaNames.Specimens;

    public override void Configure(EntityTypeBuilder<Sample> entity)
    {
        base.Configure(entity);

        entity.HasOne(sample => sample.Specimen)
              .WithMany(specimen => specimen.SpecimenSamples)
              .HasForeignKey(sample => sample.SpecimenId);

        entity.HasOne(sample => sample.Analysis)
              .WithOne(analysis => analysis.Sample)
              .HasForeignKey<Sample>(sample => sample.AnalysisId);
    }
}
