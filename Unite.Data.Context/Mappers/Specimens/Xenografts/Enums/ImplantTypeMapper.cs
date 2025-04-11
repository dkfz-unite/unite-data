using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Xenografts.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Xenografts.Enums;

internal class ImplantTypeMapper : IEntityTypeConfiguration<EnumEntity<ImplantType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<ImplantType>> entity)
    {
        var data = new EnumEntity<ImplantType>[]
        {
            ImplantType.Other.ToEnumValue(),
            ImplantType.Orhtotopical.ToEnumValue()
        };

        entity.BuildEnumEntity("implant_type", DomainDbSchemaNames.Specimens, data);
    }
}
