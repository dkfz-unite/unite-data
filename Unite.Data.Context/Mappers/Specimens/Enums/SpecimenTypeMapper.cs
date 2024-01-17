using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class SpecimenTypeMapper : IEntityTypeConfiguration<EnumEntity<SpecimenType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<SpecimenType>> entity)
    {
        var data = new EnumEntity<SpecimenType>[]
        {
            SpecimenType.Material.ToEnumValue(),
            SpecimenType.Line.ToEnumValue(),
            SpecimenType.Organoid.ToEnumValue(),
            SpecimenType.Xenograft.ToEnumValue()
        };

        entity.BuildEnumEntity("SpecimenTypes", DomainDbSchemaNames.Specimens, data);
    }
}
