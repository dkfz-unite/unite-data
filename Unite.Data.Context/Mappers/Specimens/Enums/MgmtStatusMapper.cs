using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class MgmtStatusMapper : IEntityTypeConfiguration<EnumEntity<MgmtStatus>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<MgmtStatus>> entity)
    {
        var data = new EnumEntity<MgmtStatus>[]
        {
            MgmtStatus.Unmethylated.ToEnumValue(),
            MgmtStatus.Methylated.ToEnumValue()
        };

        entity.BuildEnumEntity("MgmtStatuses", DomainDbSchemaNames.Specimens, data);
    }
}
