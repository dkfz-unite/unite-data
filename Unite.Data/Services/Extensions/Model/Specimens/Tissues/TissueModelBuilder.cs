using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Tissues;
using Unite.Data.Entities.Specimens.Tissues.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Specimens.Tissues
{
    public static class TissueModelBuilder
    {
        public static void BuildTissueModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tissue>(entity =>
            {
                entity.ToTable("Tissues");

                entity.HasKey(tissue => tissue.SpecimenId);

                entity.Property(tissue => tissue.SpecimenId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(specimen => specimen.ReferenceId)
                      .HasMaxLength(255);

                entity.Property(tissue => tissue.TypeId)
                      .HasConversion<int>();

                entity.Property(tissue => tissue.TumourTypeId)
                      .HasConversion<int>();


                entity.HasOne<EnumValue<TissueType>>()
                      .WithMany()
                      .HasForeignKey(tissue => tissue.TypeId);

                entity.HasOne<EnumValue<TumourType>>()
                      .WithMany()
                      .HasForeignKey(tissue => tissue.TumourTypeId);

                entity.HasOne(tissue => tissue.Source)
                      .WithMany()
                      .HasForeignKey(tissue => tissue.SourceId);

                entity.HasOne<Specimen>()
                      .WithOne(specimen => specimen.Tissue)
                      .HasForeignKey<Tissue>(tissue => tissue.SpecimenId)
                      .IsRequired();


                entity.HasIndex(specimen => specimen.ReferenceId);
            });
        }
    }
}
