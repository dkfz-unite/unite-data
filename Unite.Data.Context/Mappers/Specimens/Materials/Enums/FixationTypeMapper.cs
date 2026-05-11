using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Materials.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Materials.Enums;

internal class FixationTypeMapper : EnumEntityMapper<FixationType>
{
    protected override string TableName => "fixation_type";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
