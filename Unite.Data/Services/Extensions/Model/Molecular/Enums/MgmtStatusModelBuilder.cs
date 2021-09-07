using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Molecular.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Molecular.Enums
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
