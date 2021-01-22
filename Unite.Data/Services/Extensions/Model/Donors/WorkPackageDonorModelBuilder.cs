using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    public static class WorkPackageDonorModelBuilder
    {
        public static void BuildWorkPackageDonorModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkPackageDonor>(entity =>
            {
                entity.ToTable("WorkPackageDonors");

                entity.HasKey(workPackageDonor => new { workPackageDonor.WorkPackageId, workPackageDonor.DonorId });

                entity.Property(workPackageDonor => workPackageDonor.WorkPackageId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(workPackageDonor => workPackageDonor.DonorId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne(workPackageDonor => workPackageDonor.WorkPackage)
                      .WithMany(workPackage => workPackage.WorkPackageDonors)
                      .HasForeignKey(workPackageDonor => workPackageDonor.WorkPackageId);

                entity.HasOne(workPackageDonor => workPackageDonor.Donor)
                      .WithMany(donor => donor.DonorWorkPackages)
                      .HasForeignKey(workPackageDonor => workPackageDonor.DonorId);
            });
        }
    }
}
