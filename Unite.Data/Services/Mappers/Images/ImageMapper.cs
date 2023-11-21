using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Images;

internal class ImageMapper : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> entity)
    {
        entity.ToTable("Images", DomainDbSchemaNames.Images);

        entity.HasKey(image => image.Id);

        entity.Property(image => image.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(image => image.ReferenceId)
              .IsRequired()
              .HasMaxLength(255)
              .ValueGeneratedNever();

        entity.Property(image => image.DonorId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(image => image.TypeId)
              .IsRequired()
              .HasConversion<int>();


        entity.HasOne(image => image.Donor)
              .WithMany(donor => donor.Images)
              .HasForeignKey(image => image.DonorId);

        entity.HasOne<EnumValue<ImageType>>()
              .WithMany()
              .HasForeignKey(image => image.TypeId);


        entity.HasIndex(image => image.ReferenceId);
    }
}
