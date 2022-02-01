using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Mappers.Donors
{
    internal class StudyMapper : IEntityTypeConfiguration<Study>
    {
        public void Configure(EntityTypeBuilder<Study> entity)
        {
            entity.ToTable("Studies", DomainDbSchemaNames.Donors);

            entity.HasKey(study => study.Id);

            entity.HasAlternateKey(study => study.Name);

            entity.Property(study => study.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(study => study.Name)
                  .IsRequired()
                  .HasMaxLength(100);
        }
    }
}
