using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Materials.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Materials.Enums;

internal class MaterialTypeMapper : IEntityTypeConfiguration<EnumEntity<MaterialType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<MaterialType>> entity)
    {
        var data = new EnumEntity<MaterialType>[]
        {
            MaterialType.Normal.ToEnumValue(),
            MaterialType.Tumor.ToEnumValue()
        };

        entity.BuildEnumEntity("material_type", DomainDbSchemaNames.Specimens, data);
    }
}
