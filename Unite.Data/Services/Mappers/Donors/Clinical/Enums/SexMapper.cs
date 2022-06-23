using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors.Clinical.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Donors.Clinical.Enums;

internal class SexMapper : IEntityTypeConfiguration<EnumValue<Sex>>
{
    public void Configure(EntityTypeBuilder<EnumValue<Sex>> entity)
    {
        var data = new EnumValue<Sex>[]
        {
            Sex.Female.ToEnumValue(),
            Sex.Male.ToEnumValue(),
            Sex.Other.ToEnumValue()
        };

        entity.BuildEnumEntity("Sex", DomainDbSchemaNames.Donors, data);
    }
}
