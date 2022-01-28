using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Tissues.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Specimens.Tissues.Enums
{
    internal static class TissueTypeModelBuilder
    {
        internal static void BuildTissueTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<TissueType>[]
            {
                TissueType.Control.ToEnumValue(),
                TissueType.Tumor.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("TissueTypes", data);
        }
    }
}
