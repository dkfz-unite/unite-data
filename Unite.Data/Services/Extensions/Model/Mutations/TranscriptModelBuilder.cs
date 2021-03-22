using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class TranscriptModelBuilder
    {
        public static void BuildTranscriptModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transcript>(entity =>
            {
                entity.ToTable("Transcripts");

                entity.HasKey(transcript => transcript.Id);

                entity.Property(transcript => transcript.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(transcript => transcript.ChromosomeId)
                      .HasConversion<int>();


                entity.HasOne(transcript => transcript.Biotype)
                      .WithMany()
                      .HasForeignKey(transcript => transcript.BiotypeId);
            });
        }
    }
}
