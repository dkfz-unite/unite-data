using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Samples;

namespace Unite.Data.Services.Extensions.Model.Samples
{
    public static class SampleMutationModelBuilder
    {
        public static void BuildSampleMutationModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SampleMutation>(entity =>
            {
                entity.ToTable("SampleMutations");

                entity.HasKey(sampleMutation => new { sampleMutation.SampleId, sampleMutation.MutationId });

                entity.Property(sample => sample.SampleId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(sample => sample.MutationId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne(sampleMutation => sampleMutation.Sample)
                      .WithMany(sample => sample.SampleMutations)
                      .HasForeignKey(sampleMutation => sampleMutation.SampleId);

                entity.HasOne(sampleMutation => sampleMutation.Mutation)
                      .WithMany(mutation => mutation.MutationSamples)
                      .HasForeignKey(sampleMutation => sampleMutation.MutationId);
            });
        }
    }
}
