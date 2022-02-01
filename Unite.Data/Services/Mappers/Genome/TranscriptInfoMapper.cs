using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;

namespace Unite.Data.Services.Mappers.Genome
{
    internal class TranscriptInfoMapper : IEntityTypeConfiguration<TranscriptInfo>
    {
        public void Configure(EntityTypeBuilder<TranscriptInfo> entity)
        {
            entity.ToTable("TranscriptInfo", DomainDbSchemaNames.Genome);

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
        }
    }
}
