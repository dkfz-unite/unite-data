using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Cells.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Cells.Enums
{
    internal class CellLineCultureTypeMapper : IEntityTypeConfiguration<EnumValue<CellLineCultureType>>
    {
        public void Configure(EntityTypeBuilder<EnumValue<CellLineCultureType>> entity)
        {
            var data = new EnumValue<CellLineCultureType>[]
            {
                CellLineCultureType.Suspension.ToEnumValue(),
                CellLineCultureType.Adherent.ToEnumValue(),
                CellLineCultureType.Both.ToEnumValue()
            };

            entity.BuildEnumEntity("CellLineCultureTypes", DomainDbSchemaNames.Specimens, data);
        }
    }
}
