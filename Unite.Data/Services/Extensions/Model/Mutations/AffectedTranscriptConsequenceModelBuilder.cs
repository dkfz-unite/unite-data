using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    internal static class AffectedTranscriptConsequenceModelBuilder
    {
        internal static void BuildAffectedTranscriptConsequenceModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AffectedTranscriptConsequence>(entity =>
            {
                entity.ToTable("AffectedTranscriptConsequences");

                entity.HasKey(affectedTranscriptConsequence => new
                {
                    affectedTranscriptConsequence.AffectedTranscriptId,
                    affectedTranscriptConsequence.ConsequenceId
                });

                entity.Property(affectedTranscriptConsequence => affectedTranscriptConsequence.AffectedTranscriptId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(affectedTranscriptConsequence => affectedTranscriptConsequence.ConsequenceId)
                      .IsRequired()
                      .HasConversion<int>()
                      .ValueGeneratedNever();


                entity.HasOne(affectedTranscriptConsequence => affectedTranscriptConsequence.AffectedTranscript)
                      .WithMany(affectedTranscript => affectedTranscript.Consequences)
                      .HasForeignKey(affectedTranscriptConsequence => affectedTranscriptConsequence.AffectedTranscriptId);

                entity.HasOne(affectedTranscriptConsequence => affectedTranscriptConsequence.Consequence)
                      .WithMany()
                      .HasForeignKey(affectedTranscriptConsequence => affectedTranscriptConsequence.ConsequenceId);
            });
        }
    }
}
