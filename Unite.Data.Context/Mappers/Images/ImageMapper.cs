using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Images.Enums;

namespace Unite.Data.Context.Mappers.Images;

internal class ImageMapper : Base.SpecimenMapper<Image, ImageType>
{
    protected override string SchemaName => DomainDbSchemaNames.Images;
    protected override string TableName => "Images";

    public override void Configure(EntityTypeBuilder<Image> entity)
    {
        base.Configure(entity);

        entity.HasOne(image => image.Donor)
              .WithMany(donor => donor.Images)
              .HasForeignKey(image => image.DonorId);
    }
}
