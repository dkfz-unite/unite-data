using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class AnnotationTaskTypeMapper : EnumEntityMapper<AnnotationTaskType>
{
    protected override string TableName => "annotation_task_type";
    protected override string SchemaName => DomainDbSchemaNames.Common;
}
