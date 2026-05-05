using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class TaskStatusTypeMapper : IEntityTypeConfiguration<EnumEntity<TaskStatusType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<TaskStatusType>> entity)
    {
        var data = Enum.GetValues<TaskStatusType>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("task_status_type", DomainDbSchemaNames.Common, data);
    }
}
