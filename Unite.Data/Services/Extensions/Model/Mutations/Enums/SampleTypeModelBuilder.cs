using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Mutations.Enums
{
    public static class SampleTypeModelBuilder
    {
        public static void BuildSampleTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<SampleType>[]
            {
                SampleType.Control.ToEnumValue(),
                SampleType.Tumor.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("SampleTypes", data);
        }
    }
}
