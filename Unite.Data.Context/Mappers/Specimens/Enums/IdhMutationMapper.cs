using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class IdhMutationMapper : IEntityTypeConfiguration<EnumEntity<IdhMutation>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<IdhMutation>> entity)
    {
        var data = Enum.GetValues<IdhMutation>()
            .Select(e => e.ToEnumValue())
            .ToArray();
        
        entity.BuildEnumEntity("idh_mutation", DomainDbSchemaNames.Specimens, data);
    }
}
