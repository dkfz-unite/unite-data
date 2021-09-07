﻿using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Tasks.Enums
{
    internal static class TaskTargetTypeModelBuilder
    {
        internal static void BuildTaskTargetTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<TaskTargetType>[]
            {
                TaskTargetType.Donor.ToEnumValue(),
                TaskTargetType.Specimen.ToEnumValue(),
                TaskTargetType.Mutation.ToEnumValue(),
                TaskTargetType.Gene.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("TaskTargetTypes", data);
        }
    }
}
