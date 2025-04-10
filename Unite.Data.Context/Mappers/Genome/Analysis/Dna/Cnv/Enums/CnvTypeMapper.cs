using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Genome.Analysis.Dna.Cnv.Enums;

namespace Unite.Data.Context.Mappers.Genome.Analysis.Dna.Cnv.Enums;

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

        entity.BuildEnumEntity("cnv_type", DomainDbSchemaNames.Genome, data);
    }
}
