using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class IndexingTaskTypeMapper : EnumEntityMapper<IndexingTaskType>
{
    protected override string TableName => "indexing_task_type";
    protected override string SchemaName => DomainDbSchemaNames.Common;
}
