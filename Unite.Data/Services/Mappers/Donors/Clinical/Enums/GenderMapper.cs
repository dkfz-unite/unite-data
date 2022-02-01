using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors.Clinical.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Donors.Clinical.Enums
{
    internal class GenderMapper : IEntityTypeConfiguration<EnumValue<Gender>>
    {
        public void Configure(EntityTypeBuilder<EnumValue<Gender>> entity)
        {
            var data = new EnumValue<Gender>[]
            {
                Gender.Female.ToEnumValue(),
                Gender.Male.ToEnumValue(),
                Gender.Other.ToEnumValue()
            };

            entity.BuildEnumEntity("Genders", DomainDbSchemaNames.Donors, data);
        }
    }
}
