using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Xenografts.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Xenografts.Enums;

internal class ImplantTypeMapper : EnumEntityMapper<ImplantType>
{
    protected override string TableName => "implant_type";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
