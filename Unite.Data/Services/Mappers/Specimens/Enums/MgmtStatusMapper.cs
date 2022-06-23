using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Enums;

internal class MgmtStatusMapper : IEntityTypeConfiguration<EnumValue<MgmtStatus>>
{
    public void Configure(EntityTypeBuilder<EnumValue<MgmtStatus>> entity)
    {
        var data = new EnumValue<MgmtStatus>[]
        {
            MgmtStatus.Unmethylated.ToEnumValue(),
            MgmtStatus.Methylated.ToEnumValue()
        };

        entity.BuildEnumEntity("MgmtStatuses", DomainDbSchemaNames.Specimens, data);
    }
}
