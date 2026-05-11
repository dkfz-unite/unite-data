using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Lines.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Lines.Enums;

internal class CellsCultureTypeMapper : EnumEntityMapper<CellsCultureType>
{
    protected override string TableName => "cells_culture_type";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
