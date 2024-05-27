using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Genome.Analysis.Dna;
using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Context.Mappers.Genome.Analysis.Dna;

/// <summary>
/// Variant mapper
/// </summary>
/// <typeparam name="TVariant">Variant type</typeparam>
internal abstract class VariantMapper<TVariant> : Base.EntityMapper<TVariant>
    where TVariant : Variant
{
    protected override string SchemaName => DomainDbSchemaNames.Genome;
    
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


        entity.HasOne<EnumEntity<Chromosome>>()
              .WithMany()
              .HasForeignKey(variant => variant.ChromosomeId);
    }
}
