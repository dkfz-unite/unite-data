using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unite.Data.Context.Mappers.Omics.Analysis;

internal class AnalysisMapper : Base.AnalysisMapper<Entities.Omics.Analysis.Analysis, Entities.Omics.Analysis.Enums.AnalysisType>
{
    protected override string SchemaName => DomainDbSchemaNames.Omics;

    public override void Configure(EntityTypeBuilder<Entities.Omics.Analysis.Analysis> entity)
    {
        base.Configure(entity);
    }
}
