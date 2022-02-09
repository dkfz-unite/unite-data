using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Features;

namespace Unite.Data.Services.Mappers.Images.Features
{
    internal class AnalysedImageMapper : IEntityTypeConfiguration<AnalysedImage>
    {
        public void Configure(EntityTypeBuilder<AnalysedImage> entity)
        {
            entity.ToTable("AnalysedImages", DomainDbSchemaNames.Images);

            entity.HasKey(sample => sample.Id);

            entity.Property(sample => sample.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(sample => sample.AnalysisId)
                  .IsRequired()
                  .ValueGeneratedNever();

            entity.Property(sample => sample.ImageId)
                  .IsRequired()
                  .ValueGeneratedNever();


            entity.HasOne(sample => sample.Analysis)
                  .WithOne(analysis => analysis.Sample)
                  .HasForeignKey<AnalysedImage>(sample => sample.AnalysisId);

            entity.HasOne(sample => sample.Image)
                  .WithMany(image => image.ImageAnalyses)
                  .HasForeignKey(sample => sample.ImageId);
        }
    }
}
