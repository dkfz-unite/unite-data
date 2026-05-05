using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Materials.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Materials.Enums;

internal class FixationTypeMapper : IEntityTypeConfiguration<EnumEntity<FixationType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<FixationType>> entity)
    {
        var data = Enum.GetValues<FixationType>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("fixation_type", DomainDbSchemaNames.Specimens, data);
    }
}
