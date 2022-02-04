using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Features;

namespace Unite.Data.Services.Mappers.Images.Features
{
    internal class SampleMapper : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> entity)
        {
            entity.ToTable("Samples", DomainDbSchemaNames.Images);

            entity.HasKey(sample => sample.Id);

            entity.Property(sample => sample.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(sample => sample.ImageId)
                  .IsRequired()
                  .ValueGeneratedNever();

            entity.Property(sample => sample.AnalysisId)
                  .IsRequired()
                  .ValueGeneratedNever();


            entity.HasOne(sample => sample.Image)
                  .WithMany(image => image.Samples)
                  .HasForeignKey(sample => sample.ImageId);

            entity.HasOne(sample => sample.Analysis)
                  .WithOne(analysis => analysis.Sample)
                  .HasForeignKey<Sample>(sample => sample.AnalysisId);
        }
    }
}
