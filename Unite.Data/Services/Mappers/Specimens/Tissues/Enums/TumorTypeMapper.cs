using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Tissues.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Tissues.Enums;

internal class TumorTypeMapper : IEntityTypeConfiguration<EnumValue<TumorType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<TumorType>> entity)
    {
        var data = new EnumValue<TumorType>[]
        {
            TumorType.Primary.ToEnumValue(),
            TumorType.Metastasis.ToEnumValue(),
            TumorType.Recurrent.ToEnumValue()
        };

        entity.BuildEnumEntity("TumorTypes", DomainDbSchemaNames.Specimens, data);
    }
}
