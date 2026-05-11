using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Images.Enums;

namespace Unite.Data.Context.Mappers.Images.Enums;

internal class ImageTypeMapper : EnumEntityMapper<ImageType>
{
    protected override string TableName => "image_type";
    protected override string SchemaName => DomainDbSchemaNames.Images;
}
