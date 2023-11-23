using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Variants;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Genome.Variants;

/// <summary>
/// Variant mapper
/// </summary>
/// <typeparam name="TVariant">Variant type</typeparam>
internal abstract class VariantMapper<TVariant> : Base.EntityMapper<TVariant, long>
    where TVariant : Variant
{
    public override void Configure(EntityTypeBuilder<TVariant> entity)
    {
        entity.ToTable(TableName, DomainDbSchemaNames.Genome);

        entity.Property(variant => variant.ChromosomeId)
              .IsRequired()
              .HasConversion<int>();

        entity.Property(variant => variant.Start)
              .IsRequired();

        entity.Property(variant => variant.End)
              .IsRequired();


        entity.HasOne<EnumValue<Chromosome>>()
              .WithMany()
              .HasForeignKey(variant => variant.ChromosomeId);
    }
}
