using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Specimens.Enums
{
    internal static class MgmtStatusModelBuilder
    {
        internal static void BuildMgmtStatusModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<MgmtStatus>[]
            {
                MgmtStatus.Unmethylated.ToEnumValue(),
                MgmtStatus.Methylated.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("MgmtStatuses", data);
        }
    }
}
