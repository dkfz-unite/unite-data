﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Context.Mappers.Donors;

internal class StudyDonorMapper : IEntityTypeConfiguration<StudyDonor>
{
    public void Configure(EntityTypeBuilder<StudyDonor> entity)
    {
        entity.ToTable("study_donor", DomainDbSchemaNames.Donors);

        entity.HasKey(studyDonor => new
        {
            studyDonor.StudyId,
            studyDonor.DonorId
        });

        entity.Property(studyDonor => studyDonor.DonorId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(studyDonor => studyDonor.StudyId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(studyDonor => studyDonor.Donor)
              .WithMany(donor => donor.DonorStudies)
              .HasForeignKey(studyDonor => studyDonor.DonorId);

        entity.HasOne(studyDonor => studyDonor.Study)
              .WithMany(study => study.StudyDonors)
              .HasForeignKey(studyDonor => studyDonor.StudyId);
    }
}
