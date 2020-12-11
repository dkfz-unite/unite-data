using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Cells;

namespace Unite.Data.Services.Extensions.Model.Cells
{
    public static class CellLineInfoModelBuilder
    {
        public static void BuildCellLineInfoModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CellLineInfo>(entity =>
            {
                entity.ToTable("CellLineInfos");

                entity.HasKey(cellLineInfo => cellLineInfo.CellLineId);

                entity.Property(cellLineInfo => cellLineInfo.CellLineId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(cellLineInfo => cellLineInfo.DepositorName)
                      .HasMaxLength(100);

                entity.Property(cellLineInfo => cellLineInfo.DepositorEstablishment)
                      .HasMaxLength(100);

                entity.Property(cellLineInfo => cellLineInfo.FirstPublication)
                      .HasMaxLength(500);

                entity.Property(cellLineInfo => cellLineInfo.AtccLink)
                      .HasMaxLength(500);

                entity.Property(cellLineInfo => cellLineInfo.ExPasyLink)
                      .HasMaxLength(500);


                entity.HasOne<CellLine>()
                      .WithOne(cellLine => cellLine.CellLineInfo)
                      .HasForeignKey<CellLineInfo>(cellLineInfo => cellLineInfo.CellLineId)
                      .IsRequired();
            });
        }
    }
}
