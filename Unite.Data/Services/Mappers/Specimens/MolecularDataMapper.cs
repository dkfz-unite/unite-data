using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Specimens;

internal class MolecularDataMapper : IEntityTypeConfiguration<MolecularData>
{
    public void Configure(EntityTypeBuilder<MolecularData> entity)
    {
        entity.ToTable("MolecularData", DomainDbSchemaNames.Specimens);

        entity.HasKey(molecularData => molecularData.SpecimenId);

        entity.Property(molecularData => molecularData.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(molecularData => molecularData.MgmtStatusId)
              .HasConversion<int>();

        entity.Property(molecularData => molecularData.IdhStatusId)
              .HasConversion<int>();

        entity.Property(molecularData => molecularData.IdhMutationId)
              .HasConversion<int>();

        entity.Property(molecularData => molecularData.GeneExpressionSubtypeId)
              .HasConversion<int>();

        entity.Property(molecularData => molecularData.MethylationSubtypeId)
              .HasConversion<int>();


        entity.HasOne<EnumValue<MgmtStatus>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.MgmtStatusId);

        entity.HasOne<EnumValue<IdhStatus>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.IdhStatusId);

        entity.HasOne<EnumValue<IdhMutation>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.IdhMutationId);

        entity.HasOne<EnumValue<GeneExpressionSubtype>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.GeneExpressionSubtypeId);

        entity.HasOne<EnumValue<MethylationSubtype>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.MethylationSubtypeId);


        entity.HasOne<Specimen>()
              .WithOne(specimen => specimen.MolecularData)
              .HasForeignKey<MolecularData>(molecularData => molecularData.SpecimenId);
    }
}
