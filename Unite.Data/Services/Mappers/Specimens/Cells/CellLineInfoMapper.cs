using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Cells;

namespace Unite.Data.Services.Mappers.Specimens.Cells;

internal class CellLineInfoMapper : IEntityTypeConfiguration<CellLineInfo>
{
    public void Configure(EntityTypeBuilder<CellLineInfo> entity)
    {
        entity.ToTable("CellLineInfo", DomainDbSchemaNames.Specimens);

        entity.HasKey(cellLineInfo => cellLineInfo.SpecimenId);

        entity.Property(cellLineInfo => cellLineInfo.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne<CellLine>()
              .WithOne(cellLine => cellLine.Info)
              .HasForeignKey<CellLineInfo>(cellLineInfo => cellLineInfo.SpecimenId);
    }
}
