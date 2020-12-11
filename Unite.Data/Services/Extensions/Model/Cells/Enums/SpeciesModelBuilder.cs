using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Cells.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Cells.Enums
{
    public static class SpeciesModelBuilder
    {
        public static void BuildSpeciesModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<Species>[]
            {
                Species.Human.ToEnumValue(),
                Species.Mouse.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("Species", data);
        }
    }
}
