using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Tissues.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Specimens.Tissues.Enums
{
    public static class TumourTypeModelBuilder
    {
        public static void BuildTumourTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<TumourType>[]
            {
                TumourType.Primary.ToEnumValue(),
                TumourType.Metastasis.ToEnumValue(),
                TumourType.Recurrent.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("TumourTypes", data);
        }
    }
}
