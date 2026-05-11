using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Analysis.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Analysis.Enums;

internal class AnalysisTypeMapper : EnumEntityMapper<AnalysisType>
{
    protected override string TableName => "analysis_type";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
