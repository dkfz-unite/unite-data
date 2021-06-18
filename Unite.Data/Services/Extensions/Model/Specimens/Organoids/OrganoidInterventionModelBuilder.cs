using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Organoids;

namespace Unite.Data.Services.Extensions.Model.Specimens.Organoids
{
    public static class OrganoidInterventionModelBuilder
    {
        public static void BuildOrganoidInterventionModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganoidIntervention>(entity =>
            {
                entity.ToTable("OrganoidInterventions");

                entity.HasKey(intervention => intervention.Id);

                entity.Property(intervention => intervention.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(intervention => intervention.SpecimenId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(intervention => intervention.TypeId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne<Organoid>()
                      .WithMany(organoid => organoid.Interventions)
                      .HasForeignKey(intervention => intervention.SpecimenId);

                entity.HasOne(intervention => intervention.Type)
                      .WithMany()
                      .HasForeignKey(intervention => intervention.TypeId);
            });
        }
    }
}
