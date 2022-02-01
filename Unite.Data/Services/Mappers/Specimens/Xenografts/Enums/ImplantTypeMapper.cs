using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Xenografts.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Xenografts.Enums
{
    internal class ImplantTypeMapper : IEntityTypeConfiguration<EnumValue<ImplantType>>
    {
        public void Configure(EntityTypeBuilder<EnumValue<ImplantType>> entity)
        {
            var data = new EnumValue<ImplantType>[]
            {
                ImplantType.Other.ToEnumValue(),
                ImplantType.Orhtotopical.ToEnumValue()
            };

            entity.BuildEnumEntity("ImplantTypes", DomainDbSchemaNames.Specimens, data);
        }
    }
}
