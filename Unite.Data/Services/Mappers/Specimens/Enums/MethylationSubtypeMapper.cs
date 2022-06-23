using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Enums;

internal class MethylationSubtypeMapper : IEntityTypeConfiguration<EnumValue<MethylationSubtype>>
{
    public void Configure(EntityTypeBuilder<EnumValue<MethylationSubtype>> entity)
    {
        var data = new EnumValue<MethylationSubtype>[]
        {
            MethylationSubtype.H3_K27.ToEnumValue(),
            MethylationSubtype.H3_G34.ToEnumValue(),
            MethylationSubtype.RTKI.ToEnumValue(),
            MethylationSubtype.RTKII.ToEnumValue(),
            MethylationSubtype.Mesenchymal.ToEnumValue()
        };

        entity.BuildEnumEntity("MethylationSubtypes", DomainDbSchemaNames.Specimens, data);
    }
}
