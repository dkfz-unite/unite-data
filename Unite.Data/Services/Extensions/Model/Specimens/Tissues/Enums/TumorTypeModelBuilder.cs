using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Tissues.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Specimens.Tissues.Enums
{
    internal static class TumorTypeModelBuilder
    {
        internal static void BuildTumorTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<TumorType>[]
            {
                TumorType.Primary.ToEnumValue(),
                TumorType.Metastasis.ToEnumValue(),
                TumorType.Recurrent.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("TumorTypes", data);
        }
    }
}
