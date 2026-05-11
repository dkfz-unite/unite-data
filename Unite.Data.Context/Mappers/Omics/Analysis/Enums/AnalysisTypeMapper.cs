using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Omics.Analysis.Enums;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Enums;

internal class AnalysisTypeMapper : EnumEntityMapper<AnalysisType>
{
    protected override string TableName => "analysis_type";
    protected override string SchemaName => DomainDbSchemaNames.Omics;
}
