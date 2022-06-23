using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations;

namespace Unite.Data.Services.Mappers.Genome.Mutations;

internal class MutationOccurrenceMapper : IEntityTypeConfiguration<MutationOccurrence>
{
    public void Configure(EntityTypeBuilder<MutationOccurrence> entity)
    {
        entity.ToTable("MutationOccurrences", DomainDbSchemaNames.Genome);

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
    }
}
