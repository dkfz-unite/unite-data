using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Specimens.Cells;
using Unite.Data.Entities.Specimens.Cells.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Cells;

internal class CellLineMapper : IEntityTypeConfiguration<CellLine>
{
    public void Configure(EntityTypeBuilder<CellLine> entity)
    {
        entity.ToTable("CellLines", DomainDbSchemaNames.Specimens);

        entity.HasKey(cellLine => cellLine.SpecimenId);

        entity.Property(cellLine => cellLine.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(cellLine => cellLine.ReferenceId)
              .HasMaxLength(255);


        entity.HasOne<EnumEntity<Species>>()
              .WithMany()
              .HasForeignKey(cellLine => cellLine.SpeciesId);

        entity.HasOne<EnumEntity<CellLineType>>()
              .WithMany()
              .HasForeignKey(cellLine => cellLine.TypeId);

        entity.HasOne<EnumEntity<CellLineCultureType>>()
              .WithMany()
              .HasForeignKey(cellLine => cellLine.CultureTypeId);


        entity.HasOne(cellLine => cellLine.Specimen)
              .WithOne(specimen => specimen.CellLine)
              .HasForeignKey<CellLine>(cellLine => cellLine.SpecimenId)
              .IsRequired();


        entity.HasIndex(cellLine => cellLine.ReferenceId);
    }
}
