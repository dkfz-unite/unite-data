using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Images.Enums;

namespace Unite.Data.Context.Mappers.Images.Enums;

internal class ImageTypeMapper : IEntityTypeConfiguration<EnumEntity<ImageType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<ImageType>> entity)
    {
        var data = new EnumEntity<ImageType>[]
        {
            ImageType.MRI.ToEnumValue(),
            ImageType.CT.ToEnumValue()
        };

        entity.BuildEnumEntity("ImageTypes", DomainDbSchemaNames.Images, data);
    }
}
