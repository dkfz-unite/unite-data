using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Tasks;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Tasks
{
    public static class TaskModelBuilder
    {
        public static void BuildTaskModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Tasks");

                entity.HasKey(task => task.Id);

                entity.Property(task => task.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(task => task.TypeId)
                      .IsRequired()
                      .HasConversion<int>()
                      .ValueGeneratedNever();

                entity.Property(task => task.TargetTypeId)
                      .IsRequired()
                      .HasConversion<int>()
                      .ValueGeneratedNever();

                entity.Property(task => task.Target)
                      .IsRequired();

                entity.Property(task => task.Date)
                      .IsRequired();


                entity.HasOne<EnumValue<TaskType>>()
                      .WithMany()
                      .HasForeignKey(task => task.TypeId);

                entity.HasOne<EnumValue<TaskTargetType>>()
                      .WithMany()
                      .HasForeignKey(task => task.TargetTypeId);
            });
        }
    }
}
