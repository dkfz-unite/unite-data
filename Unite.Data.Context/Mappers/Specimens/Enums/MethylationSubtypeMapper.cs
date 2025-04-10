using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class MethylationSubtypeMapper : IEntityTypeConfiguration<EnumEntity<MethylationSubtype>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<MethylationSubtype>> entity)
    {
        var data = new EnumEntity<MethylationSubtype>[]
        {
            MethylationSubtype.H3_K27.ToEnumValue(),
            MethylationSubtype.H3_G34.ToEnumValue(),
            MethylationSubtype.RTKI.ToEnumValue(),
            MethylationSubtype.RTKII.ToEnumValue(),
            MethylationSubtype.Mesenchymal.ToEnumValue()
        };

        entity.BuildEnumEntity("methylation_subtype", DomainDbSchemaNames.Specimens, data);
    }
}
