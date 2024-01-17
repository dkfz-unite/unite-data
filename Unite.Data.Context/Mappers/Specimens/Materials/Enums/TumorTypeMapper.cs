using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Materials.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Materials.Enums;

internal class TumorTypeMapper : IEntityTypeConfiguration<EnumEntity<TumorType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<TumorType>> entity)
    {
        var data = new EnumEntity<TumorType>[]
        {
            TumorType.Primary.ToEnumValue(),
            TumorType.Metastasis.ToEnumValue(),
            TumorType.Recurrent.ToEnumValue()
        };

        entity.BuildEnumEntity("TumorTypes", DomainDbSchemaNames.Specimens, data);
    }
}
