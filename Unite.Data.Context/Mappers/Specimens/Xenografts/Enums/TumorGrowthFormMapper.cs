using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Xenografts.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Xenografts.Enums;

internal class TumorGrowthFormMapper : EnumEntityMapper<TumorGrowthForm>
{
    protected override string TableName => "tumor_growth_form";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
