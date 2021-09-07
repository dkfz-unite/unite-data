using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    internal static class AnalysedSampleModelBuilder
    {
        internal static void BuildAnalysedSampleModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalysedSample>(entity =>
            {
                entity.ToTable("AnalysedSamples");

                entity.HasKey(analysedSample => analysedSample.Id);

                entity.Property(analysedSample => analysedSample.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(analysedSample => analysedSample.AnalysisId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(analysedSample => analysedSample.SampleId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(analysedSample => analysedSample.MatchedSampleId)
                      .ValueGeneratedNever();


                entity.HasOne(analysedSample => analysedSample.Analysis)
                      .WithMany(analysis => analysis.AnalysedSamples)
                      .HasForeignKey(analysedSample => analysedSample.AnalysisId);

                entity.HasOne(analysedSample => analysedSample.Sample)
                      .WithMany()
                      .HasForeignKey(analysedSample => analysedSample.SampleId);

                entity.HasOne(analysedSample => analysedSample.MatchedSample)
                      .WithMany()
                      .HasForeignKey(analysedSample => analysedSample.MatchedSampleId);
            });
        }
    }
}
