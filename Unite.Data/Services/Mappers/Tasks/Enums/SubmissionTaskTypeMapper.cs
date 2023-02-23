using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Tasks.Enums;

internal class SubmissionTaskTypeMapper : IEntityTypeConfiguration<EnumValue<SubmissionTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<SubmissionTaskType>> entity)
    {
        var data = new EnumValue<SubmissionTaskType>[]
        {
            SubmissionTaskType.SSM.ToEnumValue(),
            SubmissionTaskType.CNV.ToEnumValue(),
            SubmissionTaskType.SV.ToEnumValue(),
            SubmissionTaskType.TEX.ToEnumValue()
        };

        entity.BuildEnumEntity("SubmissionTaskTypes", DomainDbSchemaNames.Common, data);
    }
}
