using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Tasks.Enums;

internal class TaskStatusTypeMapper : IEntityTypeConfiguration<EnumValue<TaskStatusType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<TaskStatusType>> entity)
    {
        var data = new EnumValue<TaskStatusType>[]
        {
            TaskStatusType.Created.ToEnumValue(),
            TaskStatusType.Preparing.ToEnumValue(),
            TaskStatusType.Processing.ToEnumValue(),
            TaskStatusType.Completed.ToEnumValue()
        };

        entity.BuildEnumEntity("TaskStatusTypes", DomainDbSchemaNames.Common, data);
    }
}
