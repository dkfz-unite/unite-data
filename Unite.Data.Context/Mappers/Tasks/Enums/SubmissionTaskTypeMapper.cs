using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class SubmissionTaskTypeMapper : EnumEntityMapper<SubmissionTaskType>
{
    protected override string TableName => "submission_task_types";
    protected override string SchemaName => DomainDbSchemaNames.Common;
}
