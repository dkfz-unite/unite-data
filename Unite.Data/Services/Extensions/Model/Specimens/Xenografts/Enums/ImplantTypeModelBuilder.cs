using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Xenografts.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Specimens.Xenografts.Enums
{
    internal static class ImplantTypeModelBuilder
    {
        internal static void BuildImplantTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<ImplantType>[]
            {
                ImplantType.Other.ToEnumValue(),
                ImplantType.Orhtotopical.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("ImplantTypes", data);
        }
    }
}
