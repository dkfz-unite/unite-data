using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Xenografts.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Xenografts.Enums;

internal class TumorGrowthFormMapper : IEntityTypeConfiguration<EnumValue<TumorGrowthForm>>
{
    public void Configure(EntityTypeBuilder<EnumValue<TumorGrowthForm>> entity)
    {
        var data = new EnumValue<TumorGrowthForm>[]
        {
            TumorGrowthForm.Encapsulated.ToEnumValue(),
            TumorGrowthForm.Invasive.ToEnumValue()
        };

        entity.BuildEnumEntity("TumorGrowthForms", DomainDbSchemaNames.Specimens, data);
    }
}
