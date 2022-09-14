using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Transcriptome;

namespace Unite.Data.Services.Mappers.Genome.Transcriptome;

public class TranscriptExpressionMapper : IEntityTypeConfiguration<TranscriptExpression>
{
    public void Configure(EntityTypeBuilder<TranscriptExpression> entity)
    {
        entity.ToTable("TranscriptExpressions", DomainDbSchemaNames.Genome);

        entity.HasKey(expression => new
        {
            expression.AnalysedSampleId,
            expression.GeneId
        });

        entity.Property(expression => expression.AnalysedSampleId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(expression => expression.GeneId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(expression => expression.AnalysedSample)
              .WithMany(analysedSample => analysedSample.TranscriptExpressions)
              .HasForeignKey(expression => expression.AnalysedSampleId);

        entity.HasOne(expression => expression.Gene)
              .WithMany(gene => gene.TranscriptExpressions)
              .HasForeignKey(expression => expression.GeneId);
    }
}
