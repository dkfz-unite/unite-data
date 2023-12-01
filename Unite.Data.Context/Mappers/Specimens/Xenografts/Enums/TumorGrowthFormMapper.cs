using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Xenografts.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Xenografts.Enums;

internal class TumorGrowthFormMapper : IEntityTypeConfiguration<EnumEntity<TumorGrowthForm>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<TumorGrowthForm>> entity)
    {
        var data = new EnumEntity<TumorGrowthForm>[]
        {
            TumorGrowthForm.Encapsulated.ToEnumValue(),
            TumorGrowthForm.Invasive.ToEnumValue()
        };

        entity.BuildEnumEntity("TumorGrowthForms", DomainDbSchemaNames.Specimens, data);
    }
}
