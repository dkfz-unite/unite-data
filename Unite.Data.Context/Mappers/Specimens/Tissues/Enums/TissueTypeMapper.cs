using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Tissues.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Tissues.Enums;

internal class TissueTypeMapper : IEntityTypeConfiguration<EnumEntity<TissueType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<TissueType>> entity)
    {
        var data = new EnumEntity<TissueType>[]
        {
            TissueType.Control.ToEnumValue(),
            TissueType.Tumor.ToEnumValue()
        };

        entity.BuildEnumEntity("TissueTypes", DomainDbSchemaNames.Specimens, data);
    }
}
