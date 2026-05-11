using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class TaskStatusTypeMapper : EnumEntityMapper<TaskStatusType>
{
    protected override string TableName => "task_status_type";
    protected override string SchemaName => DomainDbSchemaNames.Common;
}
