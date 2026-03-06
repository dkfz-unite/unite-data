using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Omics;
using Unite.Data.Entities.Omics.Analysis;
using Unite.Data.Entities.Omics.Analysis.Prot;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Prot;

internal class ProteinExpressionMapper : Base.SampleEntryMapper<ProteinExpression, Sample, Protein>
{
    protected override string SchemaName => DomainDbSchemaNames.Omics;
    protected override string TableName => "protein_expression";
    protected override string EntityColumnName => "protein_id";
    
    public override void Configure(EntityTypeBuilder<ProteinExpression> entity)
    {
        base.Configure(entity);

        entity.HasOne(expression => expression.Sample)
              .WithMany(sample => sample.ProteinExpressions)
              .HasForeignKey(expression => expression.SampleId);

        entity.HasOne(expression => expression.Entity)
              .WithMany(protein => protein.ProteinExpressions)
              .HasForeignKey(expression => expression.EntityId);
    }
}
