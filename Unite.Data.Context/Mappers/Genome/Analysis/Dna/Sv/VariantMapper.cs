using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Analysis.Dna.Sv;
using Unite.Data.Entities.Genome.Analysis.Dna.Sv.Enums;

namespace Unite.Data.Context.Mappers.Genome.Analysis.Dna.Sv;

/// <summary>
/// SV mapper
/// </summary>
internal class VariantMapper : VariantMapper<Variant>
{
    protected override string TableName => "Svs";

    public override void Configure(EntityTypeBuilder<Variant> entity)
    {
        base.Configure(entity);

        entity.Property(variant => variant.OtherChromosomeId)
              .IsRequired()
              .HasConversion<int>();

        entity.Property(variant => variant.OtherStart)
              .IsRequired();

        entity.Property(variant => variant.OtherEnd)
              .IsRequired();

        entity.Property(variant => variant.TypeId)
              .IsRequired()
              .HasConversion<int>();


        entity.HasOne<EnumEntity<Chromosome>>()
              .WithMany()
              .HasForeignKey(variant => variant.OtherChromosomeId);

        entity.HasOne<EnumEntity<SvType>>()
              .WithMany()
              .HasForeignKey(variant => variant.TypeId);
    }
}
