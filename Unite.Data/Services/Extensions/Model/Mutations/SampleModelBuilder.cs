using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    internal static class SampleModelBuilder
    {
        internal static void BuildSampleModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>(entity =>
            {
                entity.ToTable("Samples");

                entity.HasKey(sample => sample.Id);

                entity.Property(sample => sample.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(sample => sample.ReferenceId)
                      .HasMaxLength(255);

                entity.Property(sample => sample.SpecimenId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne(sample => sample.Specimen)
                      .WithMany(specimen => specimen.Samples)
                      .HasForeignKey(sample => sample.SpecimenId);
            });
        }
    }
}
