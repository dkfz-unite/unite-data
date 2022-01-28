using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Radiology;

namespace Unite.Data.Services.Mappers.Radiology
{
    internal class AnalysisParameterOccurrenceMapper : IEntityTypeConfiguration<AnalysisParameterOccurrence>
    {
        public void Configure(EntityTypeBuilder<AnalysisParameterOccurrence> entity)
        {
            entity.ToTable("AnalysisParameterOccurrences", DomainDbSchemaNames.Radiology);

            entity.HasKey(parameterOccurrence => parameterOccurrence.Id);

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
}
