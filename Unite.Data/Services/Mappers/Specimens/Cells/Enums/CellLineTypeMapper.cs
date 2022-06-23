using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Cells.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Cells.Enums;

internal class CellLineTypeMapper : IEntityTypeConfiguration<EnumValue<CellLineType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<CellLineType>> entity)
    {
        var data = new EnumValue<CellLineType>[]
        {
            CellLineType.StemCell.ToEnumValue(),
            CellLineType.Differentiated.ToEnumValue()
        };

        entity.BuildEnumEntity("CellLineTypes", DomainDbSchemaNames.Specimens, data);
    }
}
