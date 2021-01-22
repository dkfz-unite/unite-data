using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    public static class StudyModelBuilder
    {
        public static void BuildStudyModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Study>(entity =>
            {
                entity.ToTable("Studies");

                entity.HasKey(study => study.Id);

                entity.HasAlternateKey(study => study.Name);

                entity.Property(study => study.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(study => study.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }
    }
}
