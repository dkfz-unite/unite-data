using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Materials.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Materials.Enums;

internal class FixationTypeMapper : EnumEntityMapper<FixationType>
{
    protected override string TableName => "fixation_type";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
