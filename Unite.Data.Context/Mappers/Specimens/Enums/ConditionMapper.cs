using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class CategoryMapper : EnumEntityMapper<Category>
{
    protected override string TableName => "category";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
