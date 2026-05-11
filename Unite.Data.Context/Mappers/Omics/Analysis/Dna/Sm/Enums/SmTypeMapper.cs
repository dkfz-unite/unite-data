using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Omics.Analysis.Dna.Sm.Enums;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Sm.Enums;

internal class SmTypeMapper : EnumEntityMapper<SmType>
{
    protected override string TableName => "sm_type";
    protected override string SchemaName => DomainDbSchemaNames.Omics;
}
