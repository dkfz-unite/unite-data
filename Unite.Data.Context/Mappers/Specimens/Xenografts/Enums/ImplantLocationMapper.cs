using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Xenografts.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Xenografts.Enums;

internal class ImplantLocationMapper : EnumEntityMapper<ImplantLocation>
{
    protected override string TableName => "implant_location";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
