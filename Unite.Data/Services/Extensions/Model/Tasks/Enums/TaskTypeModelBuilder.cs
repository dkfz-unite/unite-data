using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Tasks.Enums
{
    internal static class TaskTypeModelBuilder
    {
        internal static void BuildTaskTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<TaskType>[]
            {
                TaskType.Indexing.ToEnumValue(),
                TaskType.Annotation.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("TaskTypes", data);
        }
    }
}
