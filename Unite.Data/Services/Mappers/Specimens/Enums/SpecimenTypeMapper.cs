using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Enums;

internal class SpecimenTypeMapper : IEntityTypeConfiguration<EnumValue<SpecimenType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<SpecimenType>> entity)
    {
        var data = new EnumValue<SpecimenType>[]
        {
            SpecimenType.Tissue.ToEnumValue(),
            SpecimenType.CellLine.ToEnumValue(),
            SpecimenType.Organoid.ToEnumValue(),
            SpecimenType.Xenograft.ToEnumValue(),
        };

        entity.BuildEnumEntity("SpecimenTypes", DomainDbSchemaNames.Specimens, data);
    }
}
