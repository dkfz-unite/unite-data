using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Images;

internal class ImageMapper : SampleMapper<Image, ImageType>
{
    public override string TableName => "Images";
    public override string SchemaName => DomainDbSchemaNames.Images;

    public override void Configure(EntityTypeBuilder<Image> entity)
    {
        base.Configure(entity);

        entity.Property(image => image.DonorId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(image => image.Donor)
              .WithMany(donor => donor.Images)
              .HasForeignKey(image => image.DonorId);
    }
}
