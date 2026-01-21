using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Context.Mappers.Specimens;

internal class TumorClassMapper : IEntityTypeConfiguration<TumorClass>
{
    public void Configure(EntityTypeBuilder<TumorClass> entity)
    {
        entity.ToTable("tumor_class", DomainDbSchemaNames.Specimens);

        entity.HasKey(tumorClass => tumorClass.Id);

        entity.HasAlternateKey(tumorClass => tumorClass.Name);

        entity.Property(tumorClass => tumorClass.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(tumorClass => tumorClass.Name)
              .IsRequired()
              .HasMaxLength(255);
    }
}
