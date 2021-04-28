using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Samples.Tissues.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Samples.Tissues.Enums
{
    public static class TissueTypeModelBuilder
    {
        public static void BuildTissueTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<TissueType>[]
            {
                TissueType.Primary.ToEnumValue(),
                TissueType.Recurrent.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("TissueTypes", data);
        }
    }
}
