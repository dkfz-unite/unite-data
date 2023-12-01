using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Tasks.Enums;

using Task = Unite.Data.Entities.Tasks.Task;

namespace Unite.Data.Context.Mappers.Tasks;

internal class TaskMapper : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> entity)
    {
        entity.ToTable("Tasks", DomainDbSchemaNames.Common);

        entity.HasKey(task => task.Id);

        entity.Property(task => task.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(task => task.SubmissionTypeId)
              .HasConversion<int>()
              .ValueGeneratedNever();

        entity.Property(task => task.IndexingTypeId)
              .HasConversion<int>()
              .ValueGeneratedNever();

        entity.Property(task => task.AnnotationTypeId)
              .HasConversion<int>()
              .ValueGeneratedNever();

        entity.Property(task => task.AnalysisTypeId)
              .HasConversion<int>()
              .ValueGeneratedNever();

        entity.Property(task => task.StatusTypeId)
              .HasConversion<int>()
              .ValueGeneratedNever();

        entity.Property(task => task.Target)
              .IsRequired();

        entity.Property(task => task.Date)
              .IsRequired();


        entity.HasOne<EnumEntity<SubmissionTaskType>>()
              .WithMany()
              .HasForeignKey(task => task.SubmissionTypeId);

        entity.HasOne<EnumEntity<IndexingTaskType>>()
              .WithMany()
              .HasForeignKey(task => task.IndexingTypeId);

        entity.HasOne<EnumEntity<AnnotationTaskType>>()
              .WithMany()
              .HasForeignKey(task => task.AnnotationTypeId);

        entity.HasOne<EnumEntity<AnalysisTaskType>>()
              .WithMany()
              .HasForeignKey(task => task.AnalysisTypeId);

        entity.HasOne<EnumEntity<TaskStatusType>>()
              .WithMany()
              .HasForeignKey(task => task.StatusTypeId);
    }
}
