using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class TertMutationMapper : IEntityTypeConfiguration<EnumEntity<TertMutation>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<TertMutation>> entity)
    {
        var data = Enum.GetValues<TertMutation>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("tert_mutation", DomainDbSchemaNames.Specimens, data);
    }
}
