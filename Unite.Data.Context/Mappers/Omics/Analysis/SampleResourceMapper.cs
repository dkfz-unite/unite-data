using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Omics.Analysis;

namespace Unite.Data.Context.Mappers.Omics.Analysis;

internal class SampleResourceMapper : Base.SampleResourceMapper<SampleResource>
{
    protected override string SchemaName => DomainDbSchemaNames.Omics;

    public override void Configure(EntityTypeBuilder<SampleResource> entity)
    {
        base.Configure(entity);

        entity.HasOne(resource => resource.Sample)
              .WithMany(sample => sample.Resources)
              .HasForeignKey(resource => resource.SampleId);
    }
}
