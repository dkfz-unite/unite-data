using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class IdhStatusMapper : IEntityTypeConfiguration<EnumEntity<IdhStatus>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<IdhStatus>> entity)
    {
        var data = new EnumEntity<IdhStatus>[]
        {
            IdhStatus.WildType.ToEnumValue(),
            IdhStatus.Mutant.ToEnumValue()
        };

        entity.BuildEnumEntity("IdhStatuses", DomainDbSchemaNames.Specimens, data);
    }
}
