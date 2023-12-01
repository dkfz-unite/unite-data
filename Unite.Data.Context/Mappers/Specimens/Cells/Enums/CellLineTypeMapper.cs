using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Cells.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Cells.Enums;

internal class CellLineTypeMapper : IEntityTypeConfiguration<EnumEntity<CellLineType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<CellLineType>> entity)
    {
        var data = new EnumEntity<CellLineType>[]
        {
            CellLineType.StemCell.ToEnumValue(),
            CellLineType.Differentiated.ToEnumValue()
        };

        entity.BuildEnumEntity("CellLineTypes", DomainDbSchemaNames.Specimens, data);
    }
}
