using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class SubmissionTaskTypeMapper : IEntityTypeConfiguration<EnumEntity<SubmissionTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<SubmissionTaskType>> entity)
    {
        var data = Enum.GetValues<SubmissionTaskType>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("submission_task_types", DomainDbSchemaNames.Common, data);
    }
}
