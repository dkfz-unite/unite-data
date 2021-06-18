using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Cells.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Specimens.Cells.Enums
{
    public static class CellLineCultureTypeModelBuilder
    {
        public static void BuildCellLineCultureTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<CellLineCultureType>[]
            {
                CellLineCultureType.Suspension.ToEnumValue(),
                CellLineCultureType.Adherent.ToEnumValue(),
                CellLineCultureType.Both.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("CellLineCultureTypes", data);
        }
    }
}
