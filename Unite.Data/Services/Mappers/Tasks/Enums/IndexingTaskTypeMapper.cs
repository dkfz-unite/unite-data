using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Tasks.Enums;

internal class IndexingTaskTypeMapper : IEntityTypeConfiguration<EnumValue<IndexingTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<IndexingTaskType>> entity)
    {
        var data = new EnumValue<IndexingTaskType>[]
        {
            IndexingTaskType.Donor.ToEnumValue(),
            IndexingTaskType.Image.ToEnumValue(),
            IndexingTaskType.Specimen.ToEnumValue(),
            IndexingTaskType.Gene.ToEnumValue(),
            IndexingTaskType.SSM.ToEnumValue(),
            IndexingTaskType.CNV.ToEnumValue(),
            IndexingTaskType.SV.ToEnumValue()
        };

        entity.BuildEnumEntity("IndexingTaskTypes", DomainDbSchemaNames.Common, data);
    }
}
