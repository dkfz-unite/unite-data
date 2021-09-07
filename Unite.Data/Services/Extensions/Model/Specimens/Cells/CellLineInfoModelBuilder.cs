using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Cells;

namespace Unite.Data.Services.Extensions.Model.Specimens.Cells
{
    internal static class CellLineInfoModelBuilder
    {
        internal static void BuildCellLineInfoModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CellLineInfo>(entity =>
            {
                entity.ToTable("CellLineInfo");

                entity.HasKey(cellLineInfo => cellLineInfo.SpecimenId);

                entity.Property(cellLineInfo => cellLineInfo.SpecimenId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne<CellLine>()
                      .WithOne(cellLine => cellLine.Info)
                      .HasForeignKey<CellLineInfo>(cellLineInfo => cellLineInfo.SpecimenId);
            });
        }
    }
}
