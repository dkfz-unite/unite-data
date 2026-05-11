using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Omics.Analysis.Dna.Cnv.Enums;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Cnv.Enums;

internal class CnvTypeMapper : EnumEntityMapper<CnvType>
{
    protected override string TableName => "cnv_type";
    protected override string SchemaName => DomainDbSchemaNames.Omics;
}
