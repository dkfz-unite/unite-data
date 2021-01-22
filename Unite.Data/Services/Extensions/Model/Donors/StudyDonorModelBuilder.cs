using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    public static class StudyDonorModelBuilder
    {
        public static void BuildStudyDonorModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudyDonor>(entity =>
            {
                entity.ToTable("StudyDonors");

                entity.HasKey(studyDonor => new { studyDonor.StudyId, studyDonor.DonorId });

                entity.Property(studyDonor => studyDonor.StudyId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(studyDonor => studyDonor.DonorId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne(studyDonor => studyDonor.Study)
                      .WithMany(study => study.StudyDonors)
                      .HasForeignKey(studyDonor => studyDonor.StudyId);

                entity.HasOne(studyDonor => studyDonor.Donor)
                      .WithMany(donor => donor.DonorStudies)
                      .HasForeignKey(studyDonor => studyDonor.DonorId);
            });
        }
    }
}
