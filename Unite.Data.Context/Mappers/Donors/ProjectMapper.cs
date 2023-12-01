using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Context.Mappers.Donors;

internal class ProjectMapper : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> entity)
    {
        entity.ToTable("Projects", DomainDbSchemaNames.Donors);

        entity.HasKey(project => project.Id);

        entity.HasAlternateKey(project => project.Name);

        entity.Property(project => project.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(project => project.Name)
              .IsRequired()
              .HasMaxLength(100);
    }
}
