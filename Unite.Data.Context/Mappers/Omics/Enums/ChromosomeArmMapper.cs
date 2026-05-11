using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Context.Mappers.Omics.Enums;

internal class ChromosomeArmMapper: EnumEntityMapper<ChromosomeArm>
{
    protected override string TableName => "chromosome_arm";
    protected override string SchemaName => DomainDbSchemaNames.Omics;
}