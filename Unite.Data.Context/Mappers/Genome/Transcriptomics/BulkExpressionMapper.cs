using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;
using Unite.Data.Entities.Genome.Analysis;
using Unite.Data.Entities.Genome.Transcriptomics;

namespace Unite.Data.Context.Mappers.Genome.Transcriptomics;

internal class BulkExpressionMapper : Base.AnalysedSampleEntryMapper<BulkExpression, AnalysedSample, Gene, int>
{
    protected override string TableName => "BulkGeneExpressions";
    protected override string AnalysedSampleColumnName => "AnalysedSampleId";
    protected override string EntityColumnName => "GeneId";
    
    public override void Configure(EntityTypeBuilder<BulkExpression> entity)
    {
        base.Configure(entity);

        entity.HasOne(expression => expression.AnalysedSample)
              .WithMany(analysedSample => analysedSample.BulkExpressions)
              .HasForeignKey(expression => expression.AnalysedSampleId);

        entity.HasOne(expression => expression.Entity)
              .WithMany(gene => gene.BulkExpressions)
              .HasForeignKey(expression => expression.EntityId);
    }
}
