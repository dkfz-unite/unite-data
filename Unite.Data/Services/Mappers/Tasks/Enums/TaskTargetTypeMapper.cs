using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Tasks.Enums;

internal class TaskTargetTypeMapper : IEntityTypeConfiguration<EnumValue<TaskTargetType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<TaskTargetType>> entity)
    {
        var data = new EnumValue<TaskTargetType>[]
        {
            TaskTargetType.Donor.ToEnumValue(),
            TaskTargetType.Specimen.ToEnumValue(),
            TaskTargetType.Mutation.ToEnumValue(),
            TaskTargetType.Gene.ToEnumValue(),
            TaskTargetType.Image.ToEnumValue()
        };

        entity.BuildEnumEntity("TaskTargetTypes", DomainDbSchemaNames.Common, data);
    }
}
