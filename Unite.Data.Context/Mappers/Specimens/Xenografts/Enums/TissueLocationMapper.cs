using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Xenografts.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Xenografts.Enums;

internal class TissueLocationMapper : IEntityTypeConfiguration<EnumEntity<TissueLocation>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<TissueLocation>> entity)
    {
        var data = new EnumEntity<TissueLocation>[]
        {
            TissueLocation.Other.ToEnumValue(),
            TissueLocation.Striatal.ToEnumValue(),
            TissueLocation.Cortical.ToEnumValue()
        };

        entity.BuildEnumEntity("TissueLocations", DomainDbSchemaNames.Specimens, data);
    }
}
