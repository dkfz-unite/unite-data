using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class ExpressionSubtypeMapper : EnumEntityMapper<ExpressionSubtype>
{
    protected override string TableName => "expression_subtype";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
