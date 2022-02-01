using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Xenografts.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Xenografts.Enums
{
    internal class TissueLocationMapper : IEntityTypeConfiguration<EnumValue<TissueLocation>>
    {
        public void Configure(EntityTypeBuilder<EnumValue<TissueLocation>> entity)
        {
            var data = new EnumValue<TissueLocation>[]
            {
                TissueLocation.Other.ToEnumValue(),
                TissueLocation.Striatal.ToEnumValue(),
                TissueLocation.Cortical.ToEnumValue()
            };

            entity.BuildEnumEntity("TissueLocations", DomainDbSchemaNames.Specimens, data);
        }
    }
}
