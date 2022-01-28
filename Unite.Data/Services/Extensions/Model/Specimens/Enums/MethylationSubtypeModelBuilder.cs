using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Specimens.Enums
{
    internal static class MethylationSubtypeModelBuilder
    {
        internal static void BuildMethylationSubtypeModel(this ModelBuilder modelBuilder)
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
