using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Context.Mappers.Genome.Analysis;

internal class AnalysedSampleResourceMapper : Base.AnalysedSampleResourceMapper<AnalysedSampleResource>
{
    protected override string SchemaName => DomainDbSchemaNames.Genome;

    public override void Configure(EntityTypeBuilder<AnalysedSampleResource> entity)
    {
        base.Configure(entity);

        entity.HasOne<AnalysedSample>()
              .WithMany(analysedSample => analysedSample.Resources)
              .HasForeignKey(resource => resource.AnalysedSampleId);
    }
}
