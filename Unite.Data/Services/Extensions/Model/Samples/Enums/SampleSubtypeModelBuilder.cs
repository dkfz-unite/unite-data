using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Samples.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Samples.Enums
{
    public static class SampleSubtypeModelBuilder
    {
        public static void BuildSampleSubtypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<SampleSubtype>[]
            {
                SampleSubtype.Primary.ToEnumValue(),
                SampleSubtype.Recurrent.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("SampleSubtypes", data);
        }
    }
}
