using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Cells.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Cells.Enums
{
    public static class MethylationSubtypeModelBuilder
    {
        public static void BuildMethylationSubtypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<MethylationSubtype>[]
            {
                MethylationSubtype.H3_K27.ToEnumValue(),
                MethylationSubtype.H3_G34.ToEnumValue(),
                MethylationSubtype.RTKI.ToEnumValue(),
                MethylationSubtype.RTKII.ToEnumValue(),
                MethylationSubtype.Mesenchymal.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("MethylationSubtypes", data);
        }
    }
}
