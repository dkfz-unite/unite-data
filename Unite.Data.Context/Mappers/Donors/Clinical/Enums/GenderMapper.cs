using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Donors.Clinical.Enums;

namespace Unite.Data.Context.Mappers.Donors.Clinical.Enums;

internal class GenderMapper : IEntityTypeConfiguration<EnumEntity<Gender>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<Gender>> entity)
    {
        var data = new EnumEntity<Gender>[]
        {
            Gender.Female.ToEnumValue(),
            Gender.Male.ToEnumValue(),
            Gender.Other.ToEnumValue()
        };

        entity.BuildEnumEntity("Genders", DomainDbSchemaNames.Donors, data);
    }
}
