using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks;

namespace Unite.Data.Services.Extensions.Model.Tasks
{
    public static class DonorIndexingTaskModelBuilder
    {
        public static void BuildDonorIndexingTaskModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonorIndexingTask>(entity =>
            {
                entity.ToTable("DonorIndexingTasks");

                entity.HasKey(task => task.Id);

                entity.Property(task => task.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(task => task.DonorId)
                      .IsRequired();

                entity.Property(task => task.Date)
                      .IsRequired();


                entity.HasOne(task => task.Donor)
                      .WithMany()
                      .HasForeignKey(task => task.DonorId)
                      .IsRequired();
            });
        }
    }
}
