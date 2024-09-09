using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class AnnotationTaskTypeMapper : IEntityTypeConfiguration<EnumEntity<AnnotationTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<AnnotationTaskType>> entity)
    {
        var data = new EnumEntity<AnnotationTaskType>[]
        {
            AnnotationTaskType.DNA_SSM.ToEnumValue(),
            AnnotationTaskType.DNA_CNV.ToEnumValue(),
            AnnotationTaskType.DNA_SV.ToEnumValue()
        };

        entity.BuildEnumEntity("AnnotationTaskTypes", DomainDbSchemaNames.Common, data);
    }
}
