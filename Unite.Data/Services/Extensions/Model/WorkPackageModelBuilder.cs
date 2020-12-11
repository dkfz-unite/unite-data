using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities;

namespace Unite.Data.Services.Extensions.Model
{
    public static class WorkPackageModelBuilder
    {
        public static void BuildWorkPackageModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkPackage>(entity =>
            {
                entity.ToTable("WorkPackages");

                entity.HasKey(workPackage => workPackage.Id);

                entity.Property(workPackage => workPackage.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(workPackage => workPackage.Name)
                      .IsRequired()
                      .HasMaxLength(100);


                entity.HasIndex(workPackage => workPackage.Name)
                      .IsUnique();
            });
        }
    }
}
