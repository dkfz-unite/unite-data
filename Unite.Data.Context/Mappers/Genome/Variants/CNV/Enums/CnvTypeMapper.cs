using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Genome.Variants.CNV.Enums;

namespace Unite.Data.Context.Mappers.Genome.Variants.CNV.Enums;

internal class CnvTypeMapper : IEntityTypeConfiguration<EnumEntity<CnvType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<CnvType>> entity)
    {
        var data = new EnumEntity<CnvType>[]
        {
            CnvType.Gain.ToEnumValue(name: "TCN gain"),
            CnvType.Loss.ToEnumValue(name: "TCN loss"),
            CnvType.Neutral.ToEnumValue(name: "TCN neutral"),
            CnvType.Undetermined.ToEnumValue(name: "Undetermined")
        };

        entity.BuildEnumEntity("CnvTypes", DomainDbSchemaNames.Genome, data);
    }
}
