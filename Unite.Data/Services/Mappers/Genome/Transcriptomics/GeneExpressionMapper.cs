using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Transcriptomics;

namespace Unite.Data.Services.Mappers.Genome.Transcriptomics;

internal class GeneExpressionMapper : IEntityTypeConfiguration<GeneExpression>
{
    public void Configure(EntityTypeBuilder<GeneExpression> entity)
    {
        entity.ToTable("GeneExpressions", DomainDbSchemaNames.Genome);

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
              .WithMany(gene => gene.GeneExpressions)
              .HasForeignKey(geneExpression => geneExpression.GeneId);

        entity.HasOne(geneExpression => geneExpression.AnalysedSample)
              .WithMany(analysedSample => analysedSample.GeneExpressions)
              .HasForeignKey(geneExpression => geneExpression.AnalysedSampleId);
    }
}
