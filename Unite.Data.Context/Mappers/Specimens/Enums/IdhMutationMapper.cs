using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class IdhMutationMapper : EnumEntityMapper<IdhMutation>
{
    protected override string TableName => "idh_mutation";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
