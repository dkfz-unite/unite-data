using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Omics;
using Unite.Data.Entities.Omics.Analysis;
using Unite.Data.Entities.Omics.Analysis.Rna;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Rna;

internal class GeneExpressionMapper : Base.SampleEntryMapper<GeneExpression, Sample, Gene>
{
    protected override string SchemaName => DomainDbSchemaNames.Omics;
    protected override string TableName => "gene_expression";
    protected override string EntityColumnName => "gene_id";
    
    public override void Configure(EntityTypeBuilder<GeneExpression> entity)
    {
        base.Configure(entity);

        entity.HasOne(expression => expression.Sample)
              .WithMany(sample => sample.GeneExpressions)
              .HasForeignKey(expression => expression.SampleId);

        entity.HasOne(expression => expression.Entity)
              .WithMany(gene => gene.GeneExpressions)
              .HasForeignKey(expression => expression.EntityId);
    }
}
