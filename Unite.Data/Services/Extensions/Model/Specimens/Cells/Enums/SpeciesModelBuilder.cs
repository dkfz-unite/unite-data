﻿using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Cells.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Specimens.Cells.Enums
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