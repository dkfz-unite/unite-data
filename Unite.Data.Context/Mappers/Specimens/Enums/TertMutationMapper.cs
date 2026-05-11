using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class TertMutationMapper : EnumEntityMapper<TertMutation>
{
    protected override string TableName => "tert_mutation";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
