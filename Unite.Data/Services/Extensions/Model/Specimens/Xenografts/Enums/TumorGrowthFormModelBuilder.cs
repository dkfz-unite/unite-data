using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Xenografts.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Specimens.Xenografts.Enums
{
    internal static class TumorGrowthFormModelBuilder
    {
        internal static void BuildTumorGrowthFormModel(this ModelBuilder modelBuilder)
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
