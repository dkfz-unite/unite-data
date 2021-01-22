using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks;

namespace Unite.Data.Services.Extensions.Model.Tasks
{
    public static class XenograftIndexingTaskModelBuilder
    {
        public static void BuildXenograftIndexingTaskModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<XenograftIndexingTask>(entity =>
            {
                entity.ToTable("XenograftIndexingTasks");

                entity.HasKey(task => task.Id);

                entity.Property(task => task.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(task => task.XenograftId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(task => task.Date)
                      .IsRequired();


                entity.HasOne(task => task.Xenograft)
                      .WithMany()
                      .HasForeignKey(task => task.XenograftId);
            });
        }
    }
}
