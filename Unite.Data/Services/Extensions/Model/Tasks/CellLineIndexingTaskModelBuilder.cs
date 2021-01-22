using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks;

namespace Unite.Data.Services.Extensions.Model.Tasks
{
    public static class CellLineIndexingTaskModelBuilder
    {
        public static void BuildCellLineIndexingTaskModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CellLineIndexingTask>(entity =>
            {
                entity.ToTable("CellLineIndexingTasks");

                entity.HasKey(task => task.Id);

                entity.Property(task => task.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(task => task.CellLineId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(task => task.Date)
                      .IsRequired();


                entity.HasOne(task => task.CellLine)
                      .WithMany()
                      .HasForeignKey(task => task.CellLineId);
            });
        }
    }
}
