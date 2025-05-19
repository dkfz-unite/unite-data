using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Entities.Omics.Analysis.Dna.Sm;
using Unite.Data.Entities.Omics.Analysis.Dna.Sm.Enums;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Sm;

/// <summary>
/// SM mapper.
/// </summary>
internal class VariantMapper : VariantMapper<Variant>
{
    protected override string TableName => "sm";

    public override void Configure(EntityTypeBuilder<Variant> entity)
    {
        base.Configure(entity);

        entity.Property(variant => variant.TypeId)
              .IsRequired()
              .HasConversion<int>();

        entity.Property(variant => variant.Ref)
              .HasMaxLength(200);

        entity.Property(variant => variant.Alt)
              .HasMaxLength(200);


        entity.HasOne<EnumEntity<SmType>>()
              .WithMany()
              .HasForeignKey(variant => variant.TypeId);
    }
}
