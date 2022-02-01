using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images;

namespace Unite.Data.Services.Mappers.Images
{
    internal class AnalysisParameterMapper : IEntityTypeConfiguration<AnalysisParameter>
    {
        public void Configure(EntityTypeBuilder<AnalysisParameter> entity)
        {
            entity.ToTable("AnalysisParameters", DomainDbSchemaNames.Images);

            entity.HasKey(parameter => parameter.Id);

            entity.Property(parameter => parameter.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(parameter => parameter.Name)
                  .IsRequired()
                  .HasMaxLength(255);


            entity.HasIndex(parameter => parameter.Name)
                  .IsUnique();
        }
    }
}
