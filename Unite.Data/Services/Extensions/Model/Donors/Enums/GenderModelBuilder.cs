using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Donors.Enums
{
    public static class GenderModelBuilder
    {
        public static void BuildGenderModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<Gender>[]
            {
                Gender.Female.ToEnumValue(),
                Gender.Male.ToEnumValue(),
                Gender.Other.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("Genders", data);
        }
    }
}
