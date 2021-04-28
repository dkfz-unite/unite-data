using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Samples.Cells;
using Unite.Data.Entities.Samples.Cells.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Samples.Cells
{
    public static class CellLineModelBuilder
    {
        public static void BuildCellLineModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CellLine>(entity =>
            {
                entity.ToTable("CellLines");

                entity.HasKey(cellLine => cellLine.Id);

                entity.Property(cellLine => cellLine.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(cellLine => cellLine.Name)
                      .IsRequired()
                      .HasMaxLength(100);


                entity.HasOne<EnumValue<CellLineType>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.TypeId);

                entity.HasOne<EnumValue<Species>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.SpeciesId);
            });
        }
    }
}
