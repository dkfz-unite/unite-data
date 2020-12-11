using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Cells.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Cells.Enums
{
    public static class MethylationStatusModelBuilder
    {
        public static void BuildMethylationStatusModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<MethylationStatus>[]
            {
                MethylationStatus.Unmethylated.ToEnumValue(),
                MethylationStatus.Methylated.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("MethylationStatuses", data);
        }
    }
}
