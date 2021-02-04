using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Epigenetics.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Epigenetics.Enums
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
