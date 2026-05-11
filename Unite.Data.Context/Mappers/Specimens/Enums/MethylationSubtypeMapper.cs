using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class MethylationSubtypeMapper : EnumEntityMapper<MethylationSubtype>
{
    protected override string TableName => "methylation_subtype";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
