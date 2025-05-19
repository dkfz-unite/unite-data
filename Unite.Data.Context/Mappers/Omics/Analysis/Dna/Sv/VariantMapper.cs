using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Omics.Enums;
using Unite.Data.Entities.Omics.Analysis.Dna.Sv;
using Unite.Data.Entities.Omics.Analysis.Dna.Sv.Enums;
using Unite.Data.Context.Mappers.Base.Entities;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Sv;

/// <summary>
/// SV mapper
/// </summary>
internal class VariantMapper : VariantMapper<Variant>
{
    protected override string TableName => "sv";

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
