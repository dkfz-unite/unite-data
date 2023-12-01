using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Genome.Variants.CNV;
using Unite.Data.Entities.Genome.Variants.CNV.Enums;

namespace Unite.Data.Context.Mappers.Genome.Variants.CNV;

/// <summary>
/// CNV mapper
/// </summary>
internal class VariantMapper : VariantMapper<Variant>
{
    protected override string TableName => "CNVs";

    public override void Configure(EntityTypeBuilder<Variant> entity)
    {
        base.Configure(entity);

        entity.Property(variant => variant.TypeId)
              .IsRequired()
              .HasConversion<int>();


        entity.HasOne<EnumEntity<CnvType>>()
              .WithMany()
              .HasForeignKey(variant => variant.TypeId);
    }
}
