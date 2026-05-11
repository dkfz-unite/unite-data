using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class WorkerTypeMapper : EnumEntityMapper<WorkerType>
{
    protected override string TableName => "worker_type";
    protected override string SchemaName => DomainDbSchemaNames.Common;
}
