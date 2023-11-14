using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Analysis;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Images.Analysis;

internal class AnalysedSampleMapper : AnalysedSampleMapper<AnalysedSample>
{
    public override string TableName => "AnalysedSamples";
    public override string SchemaName => DomainDbSchemaNames.Images;  

    public override void Configure(EntityTypeBuilder<AnalysedSample> entity)
    {
        base.Configure(entity);

        entity.HasOne(analysedSample => analysedSample.Analysis)
              .WithMany(analysis => analysis.AnalysedSamples)
              .HasForeignKey(analysedSample => analysedSample.AnalysisId);

        entity.HasOne(analysedSample => analysedSample.TargetSample)
              .WithMany(sample => sample.SampleAnalyses)
              .HasForeignKey(analysedSample => analysedSample.TargetSampleId);

        entity.HasOne(analysedSample => analysedSample.MatchedSample)
              .WithMany()
              .HasForeignKey(analysedSample => analysedSample.MatchedSampleId);
    }
}
