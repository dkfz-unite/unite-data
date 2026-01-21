using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Context.Mappers.Specimens;

internal class TumorClassificationMapper : IEntityTypeConfiguration<TumorClassification>
{
    public void Configure(EntityTypeBuilder<TumorClassification> entity)
    {
        entity.ToTable("tumor_classification", DomainDbSchemaNames.Specimens);

        entity.HasKey(classification => classification.Id);

        entity.Property(classification => classification.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(classification => classification.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(classification => classification.Specimen)
              .WithOne(specimen => specimen.TumorClassification)
              .HasForeignKey<TumorClassification>(classification => classification.SpecimenId);


        entity.HasOne(classification => classification.Superfamily)
              .WithMany()
              .HasForeignKey(classification => classification.SuperfamilyId);

        entity.HasOne(classification => classification.Family)
              .WithMany()
              .HasForeignKey(classification => classification.FamilyId);

        entity.HasOne(classification => classification.Class)
              .WithMany()
              .HasForeignKey(classification => classification.ClassId);

        entity.HasOne(classification => classification.Subclass)
              .WithMany()
              .HasForeignKey(classification => classification.SubclassId);
    }
}
