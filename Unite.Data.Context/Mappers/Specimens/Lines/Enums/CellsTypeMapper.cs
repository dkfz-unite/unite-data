using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Lines.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Lines.Enums;

internal class CellsTypeMapper : EnumEntityMapper<CellsType>
{
    protected override string TableName => "cells_type";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
