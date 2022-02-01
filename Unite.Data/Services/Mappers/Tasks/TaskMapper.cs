using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Tasks;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Tasks
{
    internal class TaskMapper : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> entity)
        {
            entity.ToTable("Tasks", DomainDbSchemaNames.Common);

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
        }
    }
}
