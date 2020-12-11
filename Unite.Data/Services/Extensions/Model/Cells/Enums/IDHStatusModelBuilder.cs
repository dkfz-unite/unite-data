using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Cells.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Cells.Enums
{
    public static class IDHStatusModelBuilder
    {
        public static void BuildIDHStatusModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<IDHStatus>[]
            {
                IDHStatus.WildType.ToEnumValue(),
                IDHStatus.Mutant.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("IDHStatuses", data);
        }
    }
}
