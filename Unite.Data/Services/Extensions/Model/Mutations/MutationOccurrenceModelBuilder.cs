using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    internal static class MutationOccurrenceModelBuilder
    {
        internal static void BuildMutationOccurrenceModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MutationOccurrence>(entity =>
            {
                entity.ToTable("MutationOccurrences");

                entity.HasKey(mutationOccurrence => mutationOccurrence.Id);

                entity.HasAlternateKey(mutationOccurrence => new
                {
                    mutationOccurrence.MutationId,
                    mutationOccurrence.AnalysedSampleId
                });

                entity.Property(mutationOccurrence => mutationOccurrence.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(mutationOccurrence => mutationOccurrence.AnalysedSampleId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(mutationOccurrence => mutationOccurrence.MutationId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne(mutationOccurrence => mutationOccurrence.AnalysedSample)
                      .WithMany(analysedSample => analysedSample.MutationOccurrences)
                      .HasForeignKey(mutationOccurrence => mutationOccurrence.AnalysedSampleId);

                entity.HasOne(mutationOccurrence => mutationOccurrence.Mutation)
                      .WithMany(mutation => mutation.MutationOccurrences)
                      .HasForeignKey(mutationOccurrence => mutationOccurrence.MutationId);
            });
        }
    }
}
