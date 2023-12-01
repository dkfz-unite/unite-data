using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Genome.Variants.SSM;
using Unite.Data.Entities.Genome.Variants.SSM.Enums;

namespace Unite.Data.Context.Mappers.Genome.Variants.SSM;

/// <summary>
/// SSM mapper
/// </summary>
internal class VariantMapper : VariantMapper<Variant>
{
    protected override string TableName => "SSMs";


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


        entity.HasOne<EnumEntity<SsmType>>()
              .WithMany()
              .HasForeignKey(variant => variant.TypeId);
    }
}
