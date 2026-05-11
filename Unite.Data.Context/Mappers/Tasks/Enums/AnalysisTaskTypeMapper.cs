using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class AnalysisTaskTypeMapper : EnumEntityMapper<AnalysisTaskType>
{
    protected override string TableName => "analysis_task_type";
    protected override string SchemaName => DomainDbSchemaNames.Common;
}
