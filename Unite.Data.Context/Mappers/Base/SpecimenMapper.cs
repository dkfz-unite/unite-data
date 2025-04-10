using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Base;
using Unite.Data.Context.Mappers.Base.Entities;

namespace Unite.Data.Context.Mappers.Base;

internal abstract class SpecimenMapper<TSpecimen, TSpecimenType> : IEntityTypeConfiguration<TSpecimen>
    where TSpecimen : Specimen<TSpecimenType>
    where TSpecimenType : struct, Enum
{
    protected abstract string SchemaName { get; }
    protected abstract string TableName { get; }

    public virtual void Configure(EntityTypeBuilder<TSpecimen> entity)
    {
        entity.ToTable(TableName, SchemaName);

        entity.HasKey(specimen => specimen.Id);

        entity.Property(specimen => specimen.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(specimen => specimen.ReferenceId)
              .IsRequired()
              .HasMaxLength(255)
              .ValueGeneratedNever();

        entity.Property(specimen => specimen.DonorId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(specimen => specimen.TypeId)
              .IsRequired()
              .HasConversion<int>();


        entity.HasOne<EnumEntity<TSpecimenType>>()
              .WithMany()
              .HasForeignKey(specimen => specimen.TypeId);


        entity.HasIndex(specimen => specimen.ReferenceId);
    }
}
