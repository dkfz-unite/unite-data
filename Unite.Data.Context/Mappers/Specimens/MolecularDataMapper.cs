using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens;

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


        entity.HasOne<EnumEntity<MgmtStatus>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.MgmtStatusId);

        entity.HasOne<EnumEntity<IdhStatus>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.IdhStatusId);

        entity.HasOne<EnumEntity<IdhMutation>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.IdhMutationId);

        entity.HasOne<EnumEntity<GeneExpressionSubtype>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.GeneExpressionSubtypeId);

        entity.HasOne<EnumEntity<MethylationSubtype>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.MethylationSubtypeId);


        entity.HasOne(molecularData => molecularData.Specimen)
              .WithOne(specimen => specimen.MolecularData)
              .HasForeignKey<MolecularData>(molecularData => molecularData.SpecimenId);
    }
}
