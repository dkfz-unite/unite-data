using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Enums
{
    internal class IdhStatusMapper : IEntityTypeConfiguration<EnumValue<IdhStatus>>
    {
        public void Configure(EntityTypeBuilder<EnumValue<IdhStatus>> entity)
        {
            var data = new EnumValue<IdhStatus>[]
            {
                IdhStatus.WildType.ToEnumValue(),
                IdhStatus.Mutant.ToEnumValue()
            };

            entity.BuildEnumEntity("IdhStatuses", DomainDbSchemaNames.Specimens, data);
        }
    }
}
