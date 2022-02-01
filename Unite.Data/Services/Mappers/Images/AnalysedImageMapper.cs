using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images;

namespace Unite.Data.Services.Mappers.Images
{
    internal class AnalysedImageMapper : IEntityTypeConfiguration<AnalysedImage>
    {
        public void Configure(EntityTypeBuilder<AnalysedImage> entity)
        {
            entity.ToTable("AnalysedImages", DomainDbSchemaNames.Images);

            entity.HasKey(analysedImage => analysedImage.Id);

            entity.Property(analysedImage => analysedImage.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(analysedImage => analysedImage.ImageId)
                  .IsRequired()
                  .ValueGeneratedNever();

            entity.Property(analysedImage => analysedImage.AnalysisId)
                  .IsRequired()
                  .ValueGeneratedNever();


            entity.HasOne(analysedImage => analysedImage.Image)
                  .WithMany(image => image.ImageAnalyses)
                  .HasForeignKey(analysedImage => analysedImage.ImageId);

            entity.HasOne(analysedImage => analysedImage.Analysis)
                  .WithOne(analysis => analysis.AnalysedImage)
                  .HasForeignKey<AnalysedImage>(analysedImage => analysedImage.AnalysisId);
        }
    }
}
