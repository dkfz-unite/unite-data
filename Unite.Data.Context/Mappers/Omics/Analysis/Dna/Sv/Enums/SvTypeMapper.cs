using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Omics.Analysis.Dna.Sv.Enums;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Sv.Enums;

internal class SvTypeMapper : EnumEntityMapper<SvType>
{
    protected override string TableName => "sv_type";
    protected override string SchemaName => DomainDbSchemaNames.Omics;
}
