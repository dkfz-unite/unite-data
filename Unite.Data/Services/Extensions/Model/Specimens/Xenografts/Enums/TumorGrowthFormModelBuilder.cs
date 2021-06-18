using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Xenografts.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Specimens.Xenografts.Enums
{
    public static class TumorGrowthFormModelBuilder
    {
        public static void BuildTumorGrowthFormModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<TumorGrowthForm>[]
            {
                TumorGrowthForm.Encapsulated.ToEnumValue(),
                TumorGrowthForm.Invasive.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("TumorGrowthForms", data);
        }
    }
}
