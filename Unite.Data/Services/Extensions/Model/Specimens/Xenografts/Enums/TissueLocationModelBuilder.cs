﻿using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Xenografts.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Specimens.Xenografts.Enums
{
    internal static class TissueLocationModelBuilder
    {
        internal static void BuildTissueLocationModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<TissueLocation>[]
            {
                TissueLocation.Other.ToEnumValue(),
                TissueLocation.Striatal.ToEnumValue(),
                TissueLocation.Cortical.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("TissueLocations", data);
        }
    }
}
