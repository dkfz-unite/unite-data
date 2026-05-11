using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Images.Analysis.Enums;

namespace Unite.Data.Context.Mappers.Images.Analysis.Enums;

internal class AnalysisTypeMapper : EnumEntityMapper<AnalysisType>
{
    protected override string TableName => "analysis_type";
    protected override string SchemaName => DomainDbSchemaNames.Images;
}
