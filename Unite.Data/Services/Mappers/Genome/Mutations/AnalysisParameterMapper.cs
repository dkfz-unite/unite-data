using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations;

namespace Unite.Data.Services.Mappers.Genome.Mutations;

public class AnalysisParameterMapper : IEntityTypeConfiguration<AnalysisParameter>
{
    public void Configure(EntityTypeBuilder<AnalysisParameter> entity)
    {
        entity.ToTable("AnalysisParameters", DomainDbSchemaNames.Genome);

        entity.HasKey(parameter => parameter.Id);

        entity.HasAlternateKey(parameter => parameter.Name);

        entity.Property(parameter => parameter.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(parameter => parameter.Name)
              .IsRequired()
              .HasMaxLength(255);
    }
}
