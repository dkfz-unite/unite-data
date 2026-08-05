using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Context.Mappers.Donors;

public class ProjectUserMapper : IEntityTypeConfiguration<ProjectUser>
{
    public void Configure(EntityTypeBuilder<ProjectUser> entity)
    {
        entity.ToTable("project_user", DomainDbSchemaNames.Donors);

        entity.HasKey(projectUser => new
        {
            projectUser.ProjectId,
            projectUser.UserId
        });

        entity.Property(projectUser => projectUser.UserId)
            .IsRequired()
            .ValueGeneratedNever();

        entity.Property(projectUser => projectUser.ProjectId)
            .IsRequired()
            .ValueGeneratedNever();


        entity.HasOne(projectUser => projectUser.User)
            .WithMany(user => user.UserProjects)
            .HasForeignKey(projectUser => projectUser.UserId);

        entity.HasOne(projectUser => projectUser.Project)
            .WithMany(project => project.ProjectUsers)
            .HasForeignKey(projectUser => projectUser.ProjectId);
    }
}