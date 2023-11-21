using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Images.Enums;

internal class ImageTypeMapper : IEntityTypeConfiguration<EnumValue<ImageType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<ImageType>> entity)
    {
        var data = new EnumValue<ImageType>[]
        {
            ImageType.MRI.ToEnumValue(),
            ImageType.CT.ToEnumValue()
        };

        entity.BuildEnumEntity("ImageTypes", DomainDbSchemaNames.Images, data);
    }
}
