using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    internal static class AffectedTranscriptModelBuilder
    {
        internal static void BuildAffectedTranscriptModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffectedTranscript>(entity =>
            {
                entity.ToTable("AffectedTranscripts");

                entity.HasKey(affectedTranscript => affectedTranscript.Id);

                entity.HasAlternateKey(affectedTranscript => new
                {
                    affectedTranscript.MutationId,
                    affectedTranscript.TranscriptId
                });

                entity.Property(affectedTranscript => affectedTranscript.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(affectedTranscript => affectedTranscript.MutationId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(affectedTranscript => affectedTranscript.TranscriptId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne(affectedTranscript => affectedTranscript.Mutation)
                      .WithMany(mutation => mutation.AffectedTranscripts)
                      .HasForeignKey(affectedTranscript => affectedTranscript.MutationId);

                entity.HasOne(affectedTranscript => affectedTranscript.Transcript)
                      .WithMany()
                      .HasForeignKey(affectedTranscript => affectedTranscript.TranscriptId);
            });
        }
    }
}
