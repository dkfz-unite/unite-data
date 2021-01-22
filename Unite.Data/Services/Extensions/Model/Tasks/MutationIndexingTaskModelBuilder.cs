using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks;

namespace Unite.Data.Services.Extensions.Model.Tasks
{
    public static class MutationIndexingTaskModelBuilder
    {
        public static void BuildMutationIndexingTaskModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MutationIndexingTask>(entity =>
            {
                entity.ToTable("MutationIndexingTasks");

                entity.HasKey(task => task.Id);

                entity.Property(task => task.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(task => task.MutationId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(task => task.Date)
                      .IsRequired();


                entity.HasOne(task => task.Mutation)
                      .WithMany()
                      .HasForeignKey(task => task.MutationId);
            });
        }
    }
}
