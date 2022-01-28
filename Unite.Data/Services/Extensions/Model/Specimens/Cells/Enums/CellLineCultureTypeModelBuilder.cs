using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Cells.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Specimens.Cells.Enums
{
    internal static class CellLineCultureTypeModelBuilder
    {
        internal static void BuildCellLineCultureTypeModel(this ModelBuilder modelBuilder)
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
