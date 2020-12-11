using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Donors.Enums
{
    public static class AgeCategoryModelBuilder
    {
        public static void BuildAgeCategoryModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<AgeCategory>[]
            {
                AgeCategory.Pediatric.ToEnumValue(),
                AgeCategory.Adult.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("AgeCategories", data);
        }
    }
}
