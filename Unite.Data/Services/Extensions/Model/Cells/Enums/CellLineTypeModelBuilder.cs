using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Cells.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Cells.Enums
{
    public static class CellLineTypeModelBuilder
    {
        public static void BuildCellLineTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<CellLineType>[]
            {
                CellLineType.GSC.ToEnumValue(),
                CellLineType.Suspension.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("CellLineTypes", data);
        }
    }
}