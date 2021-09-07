using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Xenografts;

namespace Unite.Data.Services.Extensions.Model.Specimens.Xenografts
{
    internal static class XenograftInterventionModelBuilder
    {
        internal static void BuildXenograftInterventionModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<XenograftIntervention>(entity =>
            {
                entity.ToTable("XenograftInterventions");

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


                entity.HasOne<Xenograft>()
                      .WithMany(xenograft => xenograft.Interventions)
                      .HasForeignKey(intervention => intervention.SpecimenId);

                entity.HasOne(intervention => intervention.Type)
                      .WithMany()
                      .HasForeignKey(intervention => intervention.TypeId);
            });
        }
    }
}
