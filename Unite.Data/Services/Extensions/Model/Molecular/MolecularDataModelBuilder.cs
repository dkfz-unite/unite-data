using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Molecular;
using Unite.Data.Entities.Molecular.Enums;
using Unite.Data.Entities.Samples;
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

                entity.HasNoKey();

                entity.Property(molecularData => molecularData.GeneExpressionSubtypeId)
                      .HasConversion<int>();

                entity.Property(molecularData => molecularData.IdhStatusId)
                      .HasConversion<int>();

                entity.Property(molecularData => molecularData.IdhMutationId)
                      .HasConversion<int>();

                entity.Property(molecularData => molecularData.MethylationStatusId)
                      .HasConversion<int>();

                entity.Property(molecularData => molecularData.MethylationSubtypeId)
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

                entity.HasOne<EnumValue<MethylationSubtype>>()
                      .WithMany()
                      .HasForeignKey(molecularData => molecularData.MethylationSubtypeId);


                entity.HasOne<Donor>()
                      .WithOne(donor => donor.MolecularData)
                      .HasForeignKey<MolecularData>(molecularData => molecularData.DonorId);

                entity.HasOne<Sample>()
                      .WithOne(sample => sample.MolecularData)
                      .HasForeignKey<MolecularData>(molecularData => molecularData.SampleId);
            });
        }
    }
}
