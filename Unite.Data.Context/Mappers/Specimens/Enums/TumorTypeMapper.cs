using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class TumorTypeMapper : EnumEntityMapper<TumorType>
{
    protected override string TableName => "tumor_type";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
