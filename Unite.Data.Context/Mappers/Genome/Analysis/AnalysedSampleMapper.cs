using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Context.Mappers.Genome.Analysis;

internal class AnalysedSampleMapper : Base.AnalysedSampleMapper<AnalysedSample>
{
    protected override string TableName => "AnalysedSpecimens";
    protected override string TargetSampleColumnName => "TargetSpecimenId";
    protected override string MatchedSampleColumnName => "MatchedSpecimenId";

    public override void Configure(EntityTypeBuilder<AnalysedSample> entity)
    {
        base.Configure(entity);

        entity.HasOne(analysedSample => analysedSample.Analysis)
              .WithOne(analysis => analysis.AnalysedSample)
              .HasForeignKey<AnalysedSample>(analysedSample => analysedSample.AnalysisId);

        entity.HasOne(analysedSample => analysedSample.TargetSample)
              .WithMany(specimen => specimen.AnalysedSamples)
              .HasForeignKey(analysedSample => analysedSample.TargetSampleId);

        entity.HasOne(analysedSample => analysedSample.MatchedSample)
              .WithMany(specimen => specimen.MatchedSamples)
              .HasForeignKey(analysedSample => analysedSample.MatchedSampleId);
    }
}
