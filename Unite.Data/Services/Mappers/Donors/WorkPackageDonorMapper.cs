using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Mappers.Donors
{
    internal class WorkPackageDonorMapper : IEntityTypeConfiguration<WorkPackageDonor>
    {
        public void Configure(EntityTypeBuilder<WorkPackageDonor> entity)
        {
            entity.ToTable("WorkPackageDonors", DomainDbSchemaNames.Donors);

            entity.HasKey(workPackageDonor => new
            {
                workPackageDonor.WorkPackageId,
                workPackageDonor.DonorId
            });

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
        }
    }
}
