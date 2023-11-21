using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Transcriptomics;

namespace Unite.Data.Services.Mappers.Genome.Transcriptomics;

internal class BulkExpressionMapper : IEntityTypeConfiguration<BulkExpression>
{
    public void Configure(EntityTypeBuilder<BulkExpression> entity)
    {
        entity.ToTable("BulkGeneExpressions", DomainDbSchemaNames.Genome);

        entity.HasKey(geneExpression => new
        {
            geneExpression.GeneId,
            geneExpression.AnalysedSampleId
        });

        entity.Property(geneExpression => geneExpression.GeneId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(geneExpression => geneExpression.AnalysedSampleId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.HasOne(geneExpression => geneExpression.Gene)
              .WithMany(gene => gene.BulkExpressions)
              .HasForeignKey(geneExpression => geneExpression.GeneId);

        entity.HasOne(geneExpression => geneExpression.AnalysedSample)
              .WithMany(analysedSample => analysedSample.BulkExpressions)
              .HasForeignKey(geneExpression => geneExpression.AnalysedSampleId);
    }
}
