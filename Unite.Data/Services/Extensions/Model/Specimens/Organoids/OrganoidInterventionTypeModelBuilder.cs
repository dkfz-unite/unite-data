using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Organoids;

namespace Unite.Data.Services.Extensions.Model.Specimens.Organoids
{
    public static class OrganoidInterventionTypeModelBuilder
    {
        public static void BuildOrganoidInterventionTypeModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganoidInterventionType>(entity =>
            {
                entity.ToTable("OrganoidInterventionTypes");

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
