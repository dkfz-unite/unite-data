using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Molecular.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Molecular.Enums
{
    public static class IdhStatusModelBuilder
    {
        public static void BuildIdhStatusModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<IdhStatus>[]
            {
                IdhStatus.WildType.ToEnumValue(),
                IdhStatus.Mutant.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("IdhStatuses", data);
        }
    }
}
