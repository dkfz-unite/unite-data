using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Samples;

namespace Unite.Data.Services.Extensions.Model.Samples
{
    public static class SampleModelBuilder
    {
        public static void BuildSampleModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>(entity =>
            {
                entity.ToTable("Samples");

                entity.HasKey(sample => sample.Id);

                entity.Property(sample => sample.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();


                entity.HasOne(sample => sample.Parent)
                      .WithMany(sample => sample.Children)
                      .HasForeignKey(sample => sample.ParentId);


                entity.HasOne(sample => sample.Donor)
                      .WithMany(donor => donor.Samples)
                      .HasForeignKey(sample => sample.DonorId);

                entity.HasOne(sample => sample.Tissue)
                      .WithOne(tissue => tissue.Sample)
                      .HasForeignKey<Sample>(sample => sample.TissueId);

                entity.HasOne(sample => sample.CellLine)
                      .WithOne(cellLine => cellLine.Sample)
                      .HasForeignKey<Sample>(sample => sample.CellLineId);
            });
        }
    }
}
