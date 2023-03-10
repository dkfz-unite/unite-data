using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.CNV.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Genome.Variants.CNV.Enums;

internal class CnvTypeMapper : IEntityTypeConfiguration<EnumValue<CnvType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<CnvType>> entity)
    {
        var data = new EnumValue<CnvType>[]
        {
            CnvType.Gain.ToEnumValue(name: "TCN gain"),
            CnvType.Loss.ToEnumValue(name: "TCN loss"),
            CnvType.Neutral.ToEnumValue(name: "TCN neutral"),
            CnvType.Undetermined.ToEnumValue(name: "Undetermined")
        };

        entity.BuildEnumEntity("CnvTypes", DomainDbSchemaNames.Genome, data);
    }
}
