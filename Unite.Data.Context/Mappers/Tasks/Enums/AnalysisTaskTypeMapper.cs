using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class AnalysisTaskTypeMapper : EnumEntityMapper<AnalysisTaskType>
{
    protected override string TableName => "analysis_task_type";
    protected override string SchemaName => DomainDbSchemaNames.Common;
}
