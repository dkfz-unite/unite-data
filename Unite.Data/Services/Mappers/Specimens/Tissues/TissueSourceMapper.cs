using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Tissues;

namespace Unite.Data.Services.Mappers.Specimens.Tissues;

internal class TissueSourceMapper : IEntityTypeConfiguration<TissueSource>
{
    public void Configure(EntityTypeBuilder<TissueSource> entity)
    {
        entity.ToTable("TissueSources", DomainDbSchemaNames.Specimens);

        entity.HasKey(tissueSource => tissueSource.Id);

        entity.HasAlternateKey(tissueSource => tissueSource.Value);

        entity.Property(tissueSource => tissueSource.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(tissueSource => tissueSource.Value)
              .IsRequired()
              .HasMaxLength(100);
    }
}
