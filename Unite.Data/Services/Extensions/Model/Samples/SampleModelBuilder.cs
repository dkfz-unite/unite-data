using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Samples;
using Unite.Data.Entities.Samples.Enums;
using Unite.Data.Services.Entities;

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

                entity.Property(sample => sample.DonorId)
                      .IsRequired();

                entity.Property(sample => sample.Name)
                      .HasMaxLength(500);

                entity.Property(sample => sample.Link)
                      .HasMaxLength(500);

                entity.Property(sample => sample.TypeId)
                      .HasConversion<int>();

                entity.Property(sample => sample.SubtypeId)
                      .HasConversion<int>();

                entity.Property(sample => sample.Format)
                      .HasMaxLength(100);

                entity.Property(sample => sample.Data)
                      .HasMaxLength(100);


                entity.HasOne<EnumValue<SampleType>>()
                      .WithMany()
                      .HasForeignKey(sample => sample.TypeId);

                entity.HasOne<EnumValue<SampleSubtype>>()
                      .WithMany()
                      .HasForeignKey(sample => sample.SubtypeId);


                entity.HasOne(sample => sample.Donor)
                      .WithMany(donor => donor.Samples)
                      .HasForeignKey(sample => sample.DonorId);

                entity.HasOne(sample => sample.CellLine)
                      .WithMany(cellLine => cellLine.Samples)
                      .HasForeignKey(sample => sample.CellLineId);
            });
        }
    }
}
