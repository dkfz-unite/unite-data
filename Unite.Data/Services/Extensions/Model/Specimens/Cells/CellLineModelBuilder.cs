using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Cells;
using Unite.Data.Entities.Specimens.Cells.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Specimens.Cells
{
    internal static class CellLineModelBuilder
    {
        internal static void BuildCellLineModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CellLine>(entity =>
            {
                entity.ToTable("CellLines");

                entity.HasKey(cellLine => cellLine.SpecimenId);

                entity.Property(cellLine => cellLine.SpecimenId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(cellLine => cellLine.ReferenceId)
                      .HasMaxLength(255);


                entity.HasOne<EnumValue<Species>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.SpeciesId);

                entity.HasOne<EnumValue<CellLineType>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.TypeId);

                entity.HasOne<EnumValue<CellLineCultureType>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.CultureTypeId);


                entity.HasOne<Specimen>()
                      .WithOne(specimen => specimen.CellLine)
                      .HasForeignKey<CellLine>(cellLine => cellLine.SpecimenId)
                      .IsRequired();


                entity.HasIndex(cellLine => cellLine.ReferenceId);
            });
        }
    }
}
