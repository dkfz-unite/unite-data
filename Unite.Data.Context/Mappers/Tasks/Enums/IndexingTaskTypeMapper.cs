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
        var data = new EnumEntity<IndexingTaskType>[]
        {
            IndexingTaskType.Project.ToEnumValue(),
            IndexingTaskType.Donor.ToEnumValue(),
            IndexingTaskType.Image.ToEnumValue(),
            IndexingTaskType.Specimen.ToEnumValue(),
            IndexingTaskType.Gene.ToEnumValue(),
            IndexingTaskType.SM.ToEnumValue(),
            IndexingTaskType.CNV.ToEnumValue(),
            IndexingTaskType.SV.ToEnumValue()
        };

        entity.BuildEnumEntity("indexing_task_type", DomainDbSchemaNames.Common, data);
    }
}
