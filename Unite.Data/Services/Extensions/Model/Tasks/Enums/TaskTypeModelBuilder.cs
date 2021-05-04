using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Tasks.Enums
{
    public static class TaskTypeModelBuilder
    {
        public static void BuildTaskTypeModel(this ModelBuilder modelBuilder)
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
