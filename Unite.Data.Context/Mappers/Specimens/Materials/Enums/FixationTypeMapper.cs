using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Materials.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Materials.Enums;

internal class FixationTypeMapper : IEntityTypeConfiguration<EnumEntity<FixationType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<FixationType>> entity)
    {
        var data = new EnumEntity<FixationType>[]
        {
            FixationType.FFPE.ToEnumValue(),
            FixationType.FreshFrozen.ToEnumValue()
        };

        entity.BuildEnumEntity("FixationTypes", DomainDbSchemaNames.Specimens, data);
    }
}
