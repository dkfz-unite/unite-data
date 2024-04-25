using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class SubmissionTaskTypeMapper : IEntityTypeConfiguration<EnumEntity<SubmissionTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<SubmissionTaskType>> entity)
    {
        var data = new EnumEntity<SubmissionTaskType>[]
        {
            SubmissionTaskType.SSM.ToEnumValue(),
            SubmissionTaskType.CNV.ToEnumValue(),
            SubmissionTaskType.SV.ToEnumValue(),
            SubmissionTaskType.BGE.ToEnumValue(),
            SubmissionTaskType.CGE.ToEnumValue()
        };

        entity.BuildEnumEntity("SubmissionTaskTypes", DomainDbSchemaNames.Common, data);
    }
}
