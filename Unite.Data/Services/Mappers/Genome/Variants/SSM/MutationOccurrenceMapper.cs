using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.SSM;

namespace Unite.Data.Services.Mappers.Genome.Variants.SSM;

internal class MutationOccurrenceMapper : IEntityTypeConfiguration<MutationOccurrence>
{
    public void Configure(EntityTypeBuilder<MutationOccurrence> entity)
    {
        entity.ToTable("SSMOccurrences", DomainDbSchemaNames.Genome);

        entity.HasKey(mutationOccurrence => new
        {
            mutationOccurrence.AnalysedSampleId,
            mutationOccurrence.VariantId
        });

        entity.Property(mutationOccurrence => mutationOccurrence.AnalysedSampleId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(mutationOccurrence => mutationOccurrence.VariantId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(mutationOccurrence => mutationOccurrence.AnalysedSample)
              .WithMany(analysedSample => analysedSample.MutationOccurrences)
              .HasForeignKey(mutationOccurrence => mutationOccurrence.AnalysedSampleId);

        entity.HasOne(mutationOccurrence => mutationOccurrence.Variant)
              .WithMany(mutation => mutation.Occurrences)
              .HasForeignKey(mutationOccurrence => mutationOccurrence.VariantId);
    }
}
