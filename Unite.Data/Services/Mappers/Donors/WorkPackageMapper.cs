using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Mappers.Donors
{
    internal class WorkPackageMapper : IEntityTypeConfiguration<WorkPackage>
    {
        public void Configure(EntityTypeBuilder<WorkPackage> entity)
        {
            entity.ToTable("WorkPackages", DomainDbSchemaNames.Donors);

            entity.HasKey(workPackage => workPackage.Id);

            entity.HasAlternateKey(workPackage => workPackage.Name);

            entity.Property(workPackage => workPackage.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(workPackage => workPackage.Name)
                  .IsRequired()
                  .HasMaxLength(100);
        }
    }
}
