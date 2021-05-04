using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Samples.Cells;

namespace Unite.Data.Services.Extensions.Model.Samples.Cells
{
    public static class CellLineInfoModelBuilder
    {
        public static void BuildCellLineInfoModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CellLineInfo>(entity =>
            {
                entity.ToTable("CellLineInfo");

                entity.HasKey(cellLineInfo => cellLineInfo.CellLineId);

                entity.Property(cellLineInfo => cellLineInfo.CellLineId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne<CellLine>()
                      .WithOne(cellLine => cellLine.Info)
                      .HasForeignKey<CellLineInfo>(cellLineInfo => cellLineInfo.CellLineId);
            });
        }
    }
}
