using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class SampleModelBuilder
    {
        public static void BuildSampleModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>(entity =>
            {
                entity.ToTable("Samples");

                entity.HasKey(sample => sample.SpecimenId);

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
