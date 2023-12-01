using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class TaskStatusTypeMapper : IEntityTypeConfiguration<EnumEntity<TaskStatusType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<TaskStatusType>> entity)
    {
        var data = new EnumEntity<TaskStatusType>[]
        {
            TaskStatusType.Preparing.ToEnumValue(),
            TaskStatusType.Prepared.ToEnumValue(),
            TaskStatusType.Processing.ToEnumValue(),
            TaskStatusType.Processed.ToEnumValue(),
            TaskStatusType.Failed.ToEnumValue(),
        };

        entity.BuildEnumEntity("TaskStatusTypes", DomainDbSchemaNames.Common, data);
    }
}
