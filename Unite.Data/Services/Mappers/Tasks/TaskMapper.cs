using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Tasks.Enums;
using Unite.Data.Services.Models;

using Task = Unite.Data.Entities.Tasks.Task;

namespace Unite.Data.Services.Mappers.Tasks;

internal class TaskMapper : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> entity)
    {
        entity.ToTable("Tasks", DomainDbSchemaNames.Common);

        entity.HasKey(task => task.Id);

        entity.Property(task => task.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(task => task.IndexingTypeId)
              .HasConversion<int>()
              .ValueGeneratedNever();

        entity.Property(task => task.AnnotationTypeId)
              .HasConversion<int>()
              .ValueGeneratedNever();

        entity.Property(task => task.Target)
              .IsRequired();

        entity.Property(task => task.Date)
              .IsRequired();


        entity.HasOne<EnumValue<SubmissionTaskType>>()
              .WithMany()
              .HasForeignKey(task => task.SubmissionTypeId);

        entity.HasOne<EnumValue<IndexingTaskType>>()
              .WithMany()
              .HasForeignKey(task => task.IndexingTypeId);

        entity.HasOne<EnumValue<AnnotationTaskType>>()
              .WithMany()
              .HasForeignKey(task => task.AnnotationTypeId);
    }
}
