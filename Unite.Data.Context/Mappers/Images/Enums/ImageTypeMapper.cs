using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Images.Enums;

namespace Unite.Data.Context.Mappers.Images.Enums;

internal class ImageTypeMapper : IEntityTypeConfiguration<EnumEntity<ImageType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<ImageType>> entity)
    {
        var data = new EnumEntity<ImageType>[]
        {
            ImageType.MR.ToEnumValue(),
            ImageType.CT.ToEnumValue()
        };

        entity.BuildEnumEntity("image_type", DomainDbSchemaNames.Images, data);
    }
}
