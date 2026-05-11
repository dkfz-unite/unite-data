using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class SpecimenTypeMapper : EnumEntityMapper<SpecimenType>
{
    protected override string TableName => "specimen_type";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
