using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Lines.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Lines.Enums;

internal class CellsTypeMapper : IEntityTypeConfiguration<EnumEntity<CellsType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<CellsType>> entity)
    {
        var data = new EnumEntity<CellsType>[]
        {
            CellsType.StemCell.ToEnumValue(),
            CellsType.Differentiated.ToEnumValue()
        };

        entity.BuildEnumEntity("cells_type", DomainDbSchemaNames.Specimens, data);
    }
}
