using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Organoids;

namespace Unite.Data.Services.Extensions.Model.Specimens.Organoids
{
    internal static class OrganoidModelBuilder
    {
        internal static void BuildOrganoidModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organoid>(entity =>
            {
                entity.ToTable("Organoids");

                entity.HasKey(organoid => organoid.SpecimenId);

                entity.Property(organoid => organoid.SpecimenId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(organoid => organoid.ReferenceId)
                      .HasMaxLength(255);


                entity.HasOne<Specimen>()
                      .WithOne(specimen => specimen.Organoid)
                      .HasForeignKey<Organoid>(organoid => organoid.SpecimenId)
                      .IsRequired();


                entity.HasIndex(organoid => organoid.ReferenceId);
            });
        }
    }
}
