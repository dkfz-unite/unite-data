using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors.Clinical.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Donors.Clinical.Enums
{
    internal static class GenderModelBuilder
    {
        internal static void BuildGenderModel(this ModelBuilder modelBuilder)
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
