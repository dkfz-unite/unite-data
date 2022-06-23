using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images;

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

        entity.Property(image => image.DonorId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(image => image.Donor)
              .WithMany(donor => donor.Images)
              .HasForeignKey(image => image.DonorId);
    }
}
