using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Cells.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Cells.Enums;

internal class CellLineCultureTypeMapper : IEntityTypeConfiguration<EnumEntity<CellLineCultureType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<CellLineCultureType>> entity)
    {
        var data = new EnumEntity<CellLineCultureType>[]
        {
            CellLineCultureType.Suspension.ToEnumValue(),
            CellLineCultureType.Adherent.ToEnumValue(),
            CellLineCultureType.Both.ToEnumValue()
        };

        entity.BuildEnumEntity("CellLineCultureTypes", DomainDbSchemaNames.Specimens, data);
    }
}
