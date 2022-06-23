using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations;

namespace Unite.Data.Services.Mappers.Genome.Mutations;

public class AnalysisParameterOccurrenceMapper : IEntityTypeConfiguration<AnalysisParameterOccurrence>
{
    public void Configure(EntityTypeBuilder<AnalysisParameterOccurrence> entity)
    {
        entity.ToTable("AnalysisParameterOccurrences", DomainDbSchemaNames.Genome);

        entity.HasKey(parameterOccurrence => parameterOccurrence.Id);

        entity.HasAlternateKey(parameterOccurrence => new
        {
            parameterOccurrence.ParameterId,
            parameterOccurrence.AnalysisId
        });

        entity.Property(parameterOccurrence => parameterOccurrence.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(parameterOccurrence => parameterOccurrence.AnalysisId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(parameterOccurrence => parameterOccurrence.ParameterId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(parameterOccurrence => parameterOccurrence.Value)
              .IsRequired();


        entity.HasOne(parameterOccurrence => parameterOccurrence.Analysis)
              .WithMany(analysis => analysis.ParameterOccurrences)
              .HasForeignKey(parameterOccurrence => parameterOccurrence.AnalysisId);

        entity.HasOne(parameterOccurrence => parameterOccurrence.Parameter)
              .WithMany(parameter => parameter.ParameterOccurrences)
              .HasForeignKey(parameterOccurrence => parameterOccurrence.ParameterId);
    }
}
