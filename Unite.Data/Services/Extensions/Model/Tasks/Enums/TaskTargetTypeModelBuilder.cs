using System;
using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Tasks.Enums
{
    public static class TaskTargetTypeModelBuilder
    {
        public static void BuildTaskTargetTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<TaskTargetType>[]
            {
                TaskTargetType.Donor.ToEnumValue(),
                TaskTargetType.Mutation.ToEnumValue(),
                TaskTargetType.Gene.ToEnumValue(),
                TaskTargetType.CellLine.ToEnumValue(),
                TaskTargetType.Xenograft.ToEnumValue(),
                TaskTargetType.MRIFeature.ToEnumValue(),
            };

            modelBuilder.BuildEnumValueModel("TaskTargetTypes", data);
        }
    }
}
