using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Context.Mappers.Genome.Analysis;

internal class SampleMapper : Base.SampleMapper<Sample>
{
    protected override string SchemaName => DomainDbSchemaNames.Genome;

    public override void Configure(EntityTypeBuilder<Sample> entity)
    {
        base.Configure(entity);

        entity.HasOne(sample => sample.Specimen)
              .WithMany(specimen => specimen.GenomeSamples)
              .HasForeignKey(sample => sample.SpecimenId);

        entity.HasOne(sample => sample.Analysis)
              .WithOne(analysis => analysis.Sample)
              .HasForeignKey<Sample>(sample => sample.AnalysisId);

        entity.HasOne(sample => sample.MatchedSample)
              .WithMany()
              .HasForeignKey(sample => sample.MatchedSampleId);
    }
}
