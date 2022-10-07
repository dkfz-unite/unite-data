using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.CNV;
using Unite.Data.Entities.Genome.Variants.CNV.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Genome.Variants.CNV;

/// <summary>
/// CNV mapper
/// </summary>
internal class VariantMapper : VariantMapperBase<Variant>
{
    public override string TableName => "CNVs";


    public override void Configure(EntityTypeBuilder<Variant> entity)
    {
        base.Configure(entity);


        entity.HasOne<EnumValue<SvType>>()
              .WithMany()
              .HasForeignKey(variant => variant.SvTypeId);

        entity.HasOne<EnumValue<CnaType>>()
              .WithMany()
              .HasForeignKey(variant => variant.CnaTypeId);
    }
}
