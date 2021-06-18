using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Xenografts;

namespace Unite.Data.Services.Extensions.Model.Specimens.Xenografts
{
    public static class XenograftInterventionTypeModelBuilder
    {
        public static void BuildXenograftInterventionTypeModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<XenograftInterventionType>(entity =>
            {
                entity.ToTable("XenograftInterventionTypes");

                entity.HasKey(interventionType => interventionType.Id);

                entity.HasAlternateKey(interventionType => interventionType.Name);

                entity.Property(interventionType => interventionType.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(interventionType => interventionType.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }
    }
}
