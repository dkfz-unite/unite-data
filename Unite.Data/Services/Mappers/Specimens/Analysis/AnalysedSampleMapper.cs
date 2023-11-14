using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Analysis;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Specimens.Analysis;

internal class AnalysedSampleMapper : AnalysedSampleMapper<AnalysedSample>
{
    public override string TableName => "AnalysedSamples";
    public override string SchemaName => DomainDbSchemaNames.Specimens;


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

        entity.HasMany(analysedSample => analysedSample.SsmEntries)
              .WithOne(entry => entry.AnalysedSample)
              .HasForeignKey(entry => entry.AnalysedSampleId);

        entity.HasMany(analysedSample => analysedSample.CnvEntries)
              .WithOne(entry => entry.AnalysedSample)
              .HasForeignKey(entry => entry.AnalysedSampleId);

        entity.HasMany(analysedSample => analysedSample.SvEntries)
              .WithOne(entry => entry.AnalysedSample)
              .HasForeignKey(entry => entry.AnalysedSampleId);

        entity.HasMany(analysedSample => analysedSample.BulkExpressions)
              .WithOne(entry => entry.AnalysedSample)
              .HasForeignKey(entry => entry.AnalysedSampleId);
    }
}
