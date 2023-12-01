using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Analysis;

namespace Unite.Data.Context.Mappers.Images.Analysis;

internal class AnalysedSampleMapper : Base.AnalysedSampleMapper<AnalysedSample>
{
    protected override string TableName => "AnalysedImages";
    protected override string TargetSampleColumnName => "TargetImageId";
    protected override string MatchedSampleColumnName => "MatchedImageId";

    public override void Configure(EntityTypeBuilder<AnalysedSample> entity)
    {
        base.Configure(entity);

        entity.HasOne(analysedSample => analysedSample.Analysis)
              .WithOne(analysis => analysis.AnalysedSample)
              .HasForeignKey<AnalysedSample>(analysedSample => analysedSample.AnalysisId);

        entity.HasOne(analysedSample => analysedSample.TargetSample)
              .WithMany(image => image.AnalysedSamples)
              .HasForeignKey(analysedSample => analysedSample.TargetSampleId);

        entity.HasOne(analysedSample => analysedSample.MatchedSample)
              .WithMany(image => image.MatchedSamples)
              .HasForeignKey(analysedSample => analysedSample.MatchedSampleId);
    }
}
