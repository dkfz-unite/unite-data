using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Tasks;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks;

public class WorkerMapper : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> entity)
    {
        entity.ToTable("Workers", DomainDbSchemaNames.Common);

        entity.HasKey(worker => worker.Id);

        entity.Property(worker => worker.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(worker => worker.TypeId)
              .IsRequired()
              .HasConversion<int>();

        entity.Property(worker => worker.Active)
              .IsRequired();


        entity.HasOne<EnumEntity<WorkerType>>()
              .WithMany()
              .HasForeignKey(task => task.TypeId);

        
        entity.HasData
        (
            new { Id = 1, TypeId = WorkerType.Submission, Active = true },
            new { Id = 2, TypeId = WorkerType.Annotation, Active = true },
            new { Id = 3, TypeId = WorkerType.Indexing, Active = true }
        );
    }
}
