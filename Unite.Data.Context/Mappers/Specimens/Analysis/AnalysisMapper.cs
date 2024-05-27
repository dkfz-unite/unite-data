using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unite.Data.Context.Mappers.Specimens.Analysis;

internal class AnalysisMapper : Base.AnalysisMapper<Data.Entities.Specimens.Analysis.Analysis, Data.Entities.Specimens.Analysis.Enums.AnalysisType>
{
    protected override string SchemaName => DomainDbSchemaNames.Specimens;

    public override void Configure(EntityTypeBuilder<Data.Entities.Specimens.Analysis.Analysis> entity)
    {
        base.Configure(entity);
    }
}
