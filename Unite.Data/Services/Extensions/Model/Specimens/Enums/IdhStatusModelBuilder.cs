using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Specimens.Enums
{
    internal static class IdhStatusModelBuilder
    {
        internal static void BuildIdhStatusModel(this ModelBuilder modelBuilder)
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
