using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Tissues.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Specimens.Tissues.Enums
{
    public static class TissueTypeModelBuilder
    {
        public static void BuildTissueTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<TissueType>[]
            {
                TissueType.Control.ToEnumValue(),
                TissueType.Tumour.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("TissueTypes", data);
        }
    }
}
