using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class MatchedSampleModelBuilder
    {
        public static void BuildMatchedSampleModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchedSample>(entity =>
            {
                entity.ToTable("MatchedSamples");

                entity.HasKey(matchedSample => new
                {
                    matchedSample.AnalysedSampleId,
                    matchedSample.MatchedSampleId
                });

                entity.Property(matchedSample => matchedSample.AnalysedSampleId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(matchedSample => matchedSample.MatchedSampleId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne(matchedSample => matchedSample.Analysed)
                      .WithMany(analysedSample => analysedSample.MatchedSamples)
                      .HasForeignKey(matchedSample => matchedSample.AnalysedSampleId);

                entity.HasOne(matchedSample => matchedSample.Matched)
                      .WithMany()
                      .HasForeignKey(matchedSample => matchedSample.MatchedSampleId);
            });
        }
    }
}
