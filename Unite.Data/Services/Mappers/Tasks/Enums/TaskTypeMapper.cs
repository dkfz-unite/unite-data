using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Tasks.Enums
{
    internal class TaskTypeMapper : IEntityTypeConfiguration<EnumValue<TaskType>>
    {
        public void Configure(EntityTypeBuilder<EnumValue<TaskType>> entity)
        {
            var data = new EnumValue<TaskType>[]
            {
                TaskType.Indexing.ToEnumValue(),
                TaskType.Annotation.ToEnumValue()
            };

            entity.BuildEnumEntity("TaskTypes", DomainDbSchemaNames.Common, data);
        }
    }
}
