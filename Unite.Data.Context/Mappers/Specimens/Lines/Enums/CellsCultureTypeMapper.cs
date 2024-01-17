using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Lines.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Lines.Enums;

internal class CellsCultureTypeMapper : IEntityTypeConfiguration<EnumEntity<CellsCultureType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<CellsCultureType>> entity)
    {
        var data = new EnumEntity<CellsCultureType>[]
        {
            CellsCultureType.Suspension.ToEnumValue(),
            CellsCultureType.Adherent.ToEnumValue(),
            CellsCultureType.Both.ToEnumValue()
        };

        entity.BuildEnumEntity("CellsCultureTypes", DomainDbSchemaNames.Specimens, data);
    }
}
