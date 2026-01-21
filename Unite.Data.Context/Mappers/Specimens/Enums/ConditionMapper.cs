using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class ConditionMapper : IEntityTypeConfiguration<EnumEntity<Condition>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<Condition>> entity)
    {
        var data = new EnumEntity<Condition>[]
        {
            Condition.Normal.ToEnumValue(),
            Condition.Tumor.ToEnumValue()
        };

        entity.BuildEnumEntity("condition", DomainDbSchemaNames.Specimens, data);
    }
}
