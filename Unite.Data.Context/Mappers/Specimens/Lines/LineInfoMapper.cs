using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Lines;

namespace Unite.Data.Context.Mappers.Specimens.Lines;

internal class LineInfoMapper : IEntityTypeConfiguration<LineInfo>
{
    public void Configure(EntityTypeBuilder<LineInfo> entity)
    {
        entity.ToTable("line_info", DomainDbSchemaNames.Specimens);

        entity.HasKey(info => info.SpecimenId);

        entity.Property(info => info.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne<Line>()
              .WithOne(line => line.Info)
              .HasForeignKey<LineInfo>(info => info.SpecimenId);
    }
}
