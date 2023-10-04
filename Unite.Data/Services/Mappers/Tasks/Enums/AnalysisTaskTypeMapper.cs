using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Tasks.Enums;

internal class AnalysisTaskTypeMapper : IEntityTypeConfiguration<EnumValue<AnalysisTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<AnalysisTaskType>> entity)
    {
        var data = new EnumValue<AnalysisTaskType>[]
        {
            AnalysisTaskType.DExp.ToEnumValue()
        };

        entity.BuildEnumEntity("AnalysisTaskTypes", DomainDbSchemaNames.Common, data);
    }
}
