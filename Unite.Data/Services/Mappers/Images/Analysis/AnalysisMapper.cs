using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Images.Analysis;

internal class AnalysisMapper : AnalysisMapper<Entities.Images.Analysis.Analysis, Entities.Images.Analysis.Enums.AnalysisType>
{
    public override string TableName => "Analyses";
    public override string SchemaName => DomainDbSchemaNames.Images;

    public override void Configure(EntityTypeBuilder<Entities.Images.Analysis.Analysis> entity)
    {
        base.Configure(entity);

        entity.HasMany(analysis => analysis.AnalysedSamples)
              .WithOne(analysedSample => analysedSample.Analysis)
              .HasForeignKey(analysedSample => analysedSample.AnalysisId);
    }
}
