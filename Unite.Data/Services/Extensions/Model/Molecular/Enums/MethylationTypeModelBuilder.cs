using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Molecular.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Molecular.Enums
{
    public static class MethylationTypeModelBuilder
    {
        public static void BuildMethylationTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<MethylationType>[]
            {
                MethylationType.H3_K27.ToEnumValue(),
                MethylationType.H3_G34.ToEnumValue(),
                MethylationType.RTKI.ToEnumValue(),
                MethylationType.RTKII.ToEnumValue(),
                MethylationType.Mesenchymal.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("MethylationTypes", data);
        }
    }
}
