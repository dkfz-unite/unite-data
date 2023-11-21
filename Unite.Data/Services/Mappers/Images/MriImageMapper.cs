using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images;

namespace Unite.Data.Services.Mappers.Images;

internal class MriImageMapper : IEntityTypeConfiguration<MriImage>
{
    public void Configure(EntityTypeBuilder<MriImage> entity)
    {
        entity.ToTable("MriImages", DomainDbSchemaNames.Images);

        entity.HasKey(mriImage => mriImage.ImageId);

        entity.Property(mriImage => mriImage.ImageId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(mriImage => mriImage.ReferenceId)
              .HasMaxLength(255);


        entity.HasOne(mriImage => mriImage.Image)
              .WithOne(image => image.MriImage)
              .HasForeignKey<MriImage>(mriImage => mriImage.ImageId)
              .IsRequired();
    }
}
