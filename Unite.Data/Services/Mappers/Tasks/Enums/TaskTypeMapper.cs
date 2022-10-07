using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Tasks.Enums;

internal class TaskTypeMapper : IEntityTypeConfiguration<EnumValue<AnnotationTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<AnnotationTaskType>> entity)
    {
        var data = new EnumValue<AnnotationTaskType>[]
        {
            AnnotationTaskType.SSM.ToEnumValue(),
            AnnotationTaskType.CNV.ToEnumValue(),
            AnnotationTaskType.SV.ToEnumValue(),
            AnnotationTaskType.TEX.ToEnumValue(),
            AnnotationTaskType.PEX.ToEnumValue()
        };

        entity.BuildEnumEntity("AnnotationTaskTypes", DomainDbSchemaNames.Common, data);
    }
}
