using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class AnalysisTaskTypeMapper : IEntityTypeConfiguration<EnumEntity<AnalysisTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<AnalysisTaskType>> entity)
    {
        var data = new EnumEntity<AnalysisTaskType>[]
        {
            AnalysisTaskType.RNA_DE.ToEnumValue(),
            AnalysisTaskType.RNASC.ToEnumValue()
        };

        entity.BuildEnumEntity("AnalysisTaskTypes", DomainDbSchemaNames.Common, data);
    }
}
