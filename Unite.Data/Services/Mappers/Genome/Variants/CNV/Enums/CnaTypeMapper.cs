using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.CNV.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Genome.Variants.CNV.Enums;

internal class CnaTypeMapper : IEntityTypeConfiguration<EnumValue<CnaType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<CnaType>> entity)
    {
        var data = new EnumValue<CnaType>[]
        {
            CnaType.Gain.ToEnumValue(name: "TCN gain"),
            CnaType.Loss.ToEnumValue(name: "TCN loss"),
            CnaType.Neutral.ToEnumValue(name: "TCN neutral")
        };

        entity.BuildEnumEntity("CnvCnaTypes", DomainDbSchemaNames.Genome, data);
    }
}
