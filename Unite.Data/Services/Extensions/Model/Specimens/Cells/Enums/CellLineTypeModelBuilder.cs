using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Cells.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Specimens.Cells.Enums
{
    public static class CellLineTypeModelBuilder
    {
        public static void BuildCellLineTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<CellLineType>[]
            {
                CellLineType.StemCell.ToEnumValue(),
                CellLineType.Differentiated.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("CellLineTypes", data);
        }
    }
}
