using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class WorkerTypeMapper : IEntityTypeConfiguration<EnumEntity<WorkerType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<WorkerType>> entity)
    {
        var data = new EnumEntity<WorkerType>[]
        {
            WorkerType.Submission.ToEnumValue(),
            WorkerType.Annotation.ToEnumValue(),
            WorkerType.Indexing.ToEnumValue()
        };

        entity.BuildEnumEntity("WorkerTypes", DomainDbSchemaNames.Common, data);
    }
}
