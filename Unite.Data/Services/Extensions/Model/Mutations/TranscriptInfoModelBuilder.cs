using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class TranscriptInfoModelBuilder
    {
        public static void BuildTranscriptInfoModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TranscriptInfo>(entity =>
            {
                entity.ToTable("TranscriptInfo");

                entity.HasKey(transcriptInfo => transcriptInfo.TranscriptId);

                entity.Property(transcriptInfo => transcriptInfo.TranscriptId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(transcriptInfo => transcriptInfo.EnsemblId)
                      .HasMaxLength(255);


                entity.HasOne<Transcript>()
                      .WithOne(transcript => transcript.Info)
                      .HasForeignKey<TranscriptInfo>(transcriptInfo => transcriptInfo.TranscriptId)
                      .IsRequired();


                entity.HasIndex(transcriptInfo => transcriptInfo.EnsemblId)
                      .IsUnique();
            });
        }
    }
}
