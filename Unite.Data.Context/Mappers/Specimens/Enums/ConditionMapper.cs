using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class CategoryMapper : IEntityTypeConfiguration<EnumEntity<Category>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<Category>> entity)
    {
        var data = new EnumEntity<Category>[]
        {
            Category.Normal.ToEnumValue(),
            Category.Tumor.ToEnumValue()
        };

        entity.BuildEnumEntity("category", DomainDbSchemaNames.Specimens, data);
    }
}
