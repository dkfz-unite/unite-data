using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Epigenetics.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Epigenetics.Enums
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
