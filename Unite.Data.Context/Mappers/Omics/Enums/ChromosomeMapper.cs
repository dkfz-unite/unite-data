using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Context.Mappers.Omics.Enums;

internal class ChromosomeMapper : EnumEntityMapper<Chromosome>
{
    protected override string TableName => "chromosome";
    protected override string SchemaName => DomainDbSchemaNames.Omics;
}
