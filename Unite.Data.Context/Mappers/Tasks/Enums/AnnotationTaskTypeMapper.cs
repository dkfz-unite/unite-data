using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class AnnotationTaskTypeMapper : IEntityTypeConfiguration<EnumEntity<AnnotationTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<AnnotationTaskType>> entity)
    {
        var data = Enum.GetValues<AnnotationTaskType>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("annotation_task_type", DomainDbSchemaNames.Common, data);
    }
}
