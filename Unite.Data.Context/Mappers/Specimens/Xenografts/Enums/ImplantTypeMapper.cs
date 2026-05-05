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
        var data = Enum.GetValues<ImplantType>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("implant_type", DomainDbSchemaNames.Specimens, data);
    }
}
