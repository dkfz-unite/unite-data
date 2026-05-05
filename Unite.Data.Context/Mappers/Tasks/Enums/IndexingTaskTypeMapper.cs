using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class IndexingTaskTypeMapper : IEntityTypeConfiguration<EnumEntity<IndexingTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<IndexingTaskType>> entity)
    {
        var data = Enum.GetValues<IndexingTaskType>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("indexing_task_type", DomainDbSchemaNames.Common, data);
    }
}
