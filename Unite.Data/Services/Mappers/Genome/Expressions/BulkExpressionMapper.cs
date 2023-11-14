using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;
using Unite.Data.Entities.Genome.Expressions;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Genome.Expressions;

internal class BulkExpressionMapper : AnalysisFeatureEntryMapper<BulkExpression, Gene>
{
    public override string TableName => "BulkExpressions";
    public override string SchemaName => DomainDbSchemaNames.Genome;

    public override string FeatureColumnName => "GeneId";
    public override string AnalysedSampleColumnName => "AnalysedSampleId";
    

    public override void Configure(EntityTypeBuilder<BulkExpression> entity)
    {
        base.Configure(entity);

        entity.HasOne(entry => entry.Feature)
              .WithMany(feature => feature.BulkExpressions)
              .HasForeignKey(entry => entry.FeatureId);

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.BulkExpressions)
              .HasForeignKey(entry => entry.AnalysedSampleId);
    }
}
