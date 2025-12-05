using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Context.Mappers.Specimens;

internal class TumorSubclassMapper : IEntityTypeConfiguration<TumorSubclass>
{
    public void Configure(EntityTypeBuilder<TumorSubclass> entity)
    {
        entity.ToTable("tumor_subclass", DomainDbSchemaNames.Specimens);

        entity.HasKey(tumorSubclass => tumorSubclass.Id);

        entity.HasAlternateKey(tumorSubclass => tumorSubclass.Name);

        entity.Property(tumorSubclass => tumorSubclass.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(tumorSubclass => tumorSubclass.Name)
              .IsRequired()
              .HasMaxLength(255);
    }
}
