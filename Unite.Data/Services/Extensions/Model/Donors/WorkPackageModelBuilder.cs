using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    internal static class WorkPackageModelBuilder
    {
        internal static void BuildWorkPackageModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkPackage>(entity =>
            {
                entity.ToTable("WorkPackages");

                entity.HasKey(workPackage => workPackage.Id);

                entity.HasAlternateKey(workPackage => workPackage.Name);

                entity.Property(workPackage => workPackage.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(workPackage => workPackage.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }
    }
}
