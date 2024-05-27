using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Analysis;

namespace Unite.Data.Context.Mappers.Images.Analysis;

internal class SampleMapper : Base.SampleMapper<Sample>
{
    protected override string SchemaName => DomainDbSchemaNames.Images;
    protected override string SpecimenColumnName => "ImageId";

    public override void Configure(EntityTypeBuilder<Sample> entity)
    {
        base.Configure(entity);

        entity.HasOne(sample => sample.Specimen)
              .WithMany(image => image.Samples)
              .HasForeignKey(sample => sample.SpecimenId);

        entity.HasOne(sample => sample.Analysis)
              .WithOne(analysis => analysis.Sample)
              .HasForeignKey<Sample>(sample => sample.AnalysisId);   
    }
}
