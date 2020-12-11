using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Donors.Enums
{
    public static class VitalStatusModelBuilder
    {
        public static void BuildVitalStatusModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<VitalStatus>[]
            {
                VitalStatus.Living.ToEnumValue(),
                VitalStatus.Deceased.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("VitalStatuses", data);
        }
    }
}
