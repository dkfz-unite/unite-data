using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unite.Data.Context.Mappers.Specimens.Analysis;

internal class AnalysisMapper : Base.AnalysisMapper<Entities.Specimens.Analysis.Analysis, Entities.Specimens.Analysis.Enums.AnalysisType>
{
    protected override string SchemaName => DomainDbSchemaNames.Specimens;

    public override void Configure(EntityTypeBuilder<Entities.Specimens.Analysis.Analysis> entity)
    {
        base.Configure(entity);
    }
}
