using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class AnalysisTaskTypeMapper : IEntityTypeConfiguration<EnumEntity<AnalysisTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<AnalysisTaskType>> entity)
    {
        var data = new EnumEntity<AnalysisTaskType>[]
        {
            AnalysisTaskType.DE.ToEnumValue(),
            AnalysisTaskType.SCELL.ToEnumValue(),
            AnalysisTaskType.SURV.ToEnumValue(),
            AnalysisTaskType.DM.ToEnumValue()
        };

        entity.BuildEnumEntity("analysis_task_type", DomainDbSchemaNames.Common, data);
    }
}
