using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class TranscriptConsequenceModelBuilder
    {
        public static void BuildTranscriptConsequenceModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TranscriptConsequence>(entity =>
            {
                entity.ToTable("TranscriptConsequences");

                entity.HasKey(transcriptConsequence => transcriptConsequence.Id);

                entity.HasAlternateKey(transcriptConsequence => new
                {
                    transcriptConsequence.MutationId,
                    transcriptConsequence.TranscriptId,
                    transcriptConsequence.ConsequenceId
                });

                entity.Property(transcriptConsequence => transcriptConsequence.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(transcriptConsequence => transcriptConsequence.MutationId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(transcriptConsequence => transcriptConsequence.TranscriptId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(transcriptConsequence => transcriptConsequence.ConsequenceId)
                      .IsRequired()
                      .HasConversion<int>()
                      .ValueGeneratedNever();


                entity.HasOne(transcriptConsequence => transcriptConsequence.Mutation)
                      .WithMany(mutation => mutation.TranscriptConsequences)
                      .HasForeignKey(transcriptConsequence => transcriptConsequence.MutationId);

                entity.HasOne(transcriptConsequence => transcriptConsequence.Transcript)
                      .WithMany(transcript => transcript.TranscriptConsequences)
                      .HasForeignKey(transcriptConsequence => transcriptConsequence.TranscriptId);

                entity.HasOne(transcriptConsequence => transcriptConsequence.Consequence)
                      .WithMany()
                      .HasForeignKey(transcriptConsequence => transcriptConsequence.ConsequenceId);
            });
        }
    }
}
