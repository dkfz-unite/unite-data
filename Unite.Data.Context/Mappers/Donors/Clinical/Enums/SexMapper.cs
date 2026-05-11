using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Donors.Clinical.Enums;

namespace Unite.Data.Context.Mappers.Donors.Clinical.Enums;

internal class SexMapper : EnumEntityMapper<Sex>
{
    protected override string TableName => "sex";
    protected override string SchemaName => DomainDbSchemaNames.Donors;
}
