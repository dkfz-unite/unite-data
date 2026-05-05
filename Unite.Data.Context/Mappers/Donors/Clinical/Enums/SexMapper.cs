using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Donors.Clinical.Enums;

namespace Unite.Data.Context.Mappers.Donors.Clinical.Enums;

internal class SexMapper : IEntityTypeConfiguration<EnumEntity<Sex>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<Sex>> entity)
    {
        var data = Enum.GetValues<Sex>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("sex", DomainDbSchemaNames.Donors, data);
    }
}
