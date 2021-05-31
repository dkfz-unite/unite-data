using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Molecular;
using Unite.Data.Entities.Molecular.Enums;
using Unite.Data.Entities.Specimens;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Molecular
{
    public static class MolecularDataModelBuilder
    {
        public static void BuildMolecularDataModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MolecularData>(entity =>
            {
                entity.ToTable("MolecularData");

                entity.HasKey(molecularData => molecularData.SpecimenId);

                entity.Property(molecularData => molecularData.SpecimenId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(molecularData => molecularData.GeneExpressionSubtypeId)
                      .HasConversion<int>();

                entity.Property(molecularData => molecularData.IdhStatusId)
                      .HasConversion<int>();

                entity.Property(molecularData => molecularData.IdhMutationId)
                      .HasConversion<int>();

                entity.Property(molecularData => molecularData.MethylationStatusId)
                      .HasConversion<int>();

                entity.Property(molecularData => molecularData.MethylationTypeId)
                      .HasConversion<int>();


                entity.HasOne<EnumValue<GeneExpressionSubtype>>()
                      .WithMany()
                      .HasForeignKey(molecularData => molecularData.GeneExpressionSubtypeId);

                entity.HasOne<EnumValue<IDHStatus>>()
                      .WithMany()
                      .HasForeignKey(molecularData => molecularData.IdhStatusId);

                entity.HasOne<EnumValue<IDHMutation>>()
                      .WithMany()
                      .HasForeignKey(molecularData => molecularData.IdhMutationId);

                entity.HasOne<EnumValue<MethylationStatus>>()
                      .WithMany()
                      .HasForeignKey(molecularData => molecularData.MethylationStatusId);

                entity.HasOne<EnumValue<MethylationType>>()
                      .WithMany()
                      .HasForeignKey(molecularData => molecularData.MethylationTypeId);


                entity.HasOne<Specimen>()
                      .WithOne(specimen => specimen.MolecularData)
                      .HasForeignKey<MolecularData>(molecularData => molecularData.SpecimenId);
            });
        }
    }
}
