using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Analysis.Radiomics;

namespace Unite.Data.Context.Mappers.Images.Analysis.Radiomics;

internal class FeatureMapper : Base.EntityMapper<Feature>
{
    protected override string SchemaName => DomainDbSchemaNames.Images;
    protected override string TableName => "RadiomicsFeatures";

    public override void Configure(EntityTypeBuilder<Feature> entity)
    {
        base.Configure(entity);

        entity.HasAlternateKey(feature => feature.Name);

        entity.Property(feature => feature.Name)
              .IsRequired()
              .HasMaxLength(255);
    }
}
