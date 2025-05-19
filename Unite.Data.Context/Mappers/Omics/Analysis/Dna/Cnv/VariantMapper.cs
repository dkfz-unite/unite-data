using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Entities.Omics.Analysis.Dna.Cnv;
using Unite.Data.Entities.Omics.Analysis.Dna.Cnv.Enums;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Cnv;

/// <summary>
/// CNV mapper.
/// </summary>
internal class VariantMapper : VariantMapper<Variant>
{
    protected override string TableName => "cnv";

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
