using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Xenografts.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Xenografts.Enums;

internal class TumorGrowthFormMapper : IEntityTypeConfiguration<EnumEntity<TumorGrowthForm>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<TumorGrowthForm>> entity)
    {
        var data = Enum.GetValues<TumorGrowthForm>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("tumor_growth_form", DomainDbSchemaNames.Specimens, data);
    }
}
