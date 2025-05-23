﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Context.Mappers.Donors;

internal class ProjectDonorMapper : IEntityTypeConfiguration<ProjectDonor>
{
    public void Configure(EntityTypeBuilder<ProjectDonor> entity)
    {
        entity.ToTable("project_donor", DomainDbSchemaNames.Donors);

        entity.HasKey(projectDonor => new
        {
            projectDonor.ProjectId,
            projectDonor.DonorId
        });

        entity.Property(projectDonor => projectDonor.DonorId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(projectDonor => projectDonor.ProjectId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(projectDonor => projectDonor.Donor)
              .WithMany(donor => donor.DonorProjects)
              .HasForeignKey(projectDonor => projectDonor.DonorId);

        entity.HasOne(projectDonor => projectDonor.Project)
              .WithMany(project => project.ProjectDonors)
              .HasForeignKey(projectDonor => projectDonor.ProjectId);
    }
}
