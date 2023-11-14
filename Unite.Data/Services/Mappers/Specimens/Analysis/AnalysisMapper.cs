using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Specimens.Analysis;

internal class AnalysisMapper : AnalysisMapper<Entities.Specimens.Analysis.Analysis, Entities.Specimens.Analysis.Enums.AnalysisType>
{
    public override string TableName => "Analyses";
    public override string SchemaName => DomainDbSchemaNames.Specimens;

    public override void Configure(EntityTypeBuilder<Entities.Specimens.Analysis.Analysis> entity)
    {
        base.Configure(entity);

        entity.HasMany(analysis => analysis.AnalysedSamples)
              .WithOne(analysedSample => analysedSample.Analysis)
              .HasForeignKey(analysedSample => analysedSample.AnalysisId);
    }
}
