using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images;

namespace Unite.Data.Context.Mappers.Images;

internal class MrImageMapper : IEntityTypeConfiguration<MrImage>
{
    public void Configure(EntityTypeBuilder<MrImage> entity)
    {
        entity.ToTable("mr_image", DomainDbSchemaNames.Images);

        entity.HasKey(mrImage => mrImage.ImageId);

        entity.Property(mrImage => mrImage.ImageId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(mrImage => mrImage.Image)
              .WithOne(image => image.MrImage)
              .HasForeignKey<MrImage>(mrImage => mrImage.ImageId)
              .IsRequired();
    }
}
