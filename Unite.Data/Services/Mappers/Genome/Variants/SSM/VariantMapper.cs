using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.SSM;
using Unite.Data.Entities.Genome.Variants.SSM.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Genome.Variants.SSM;

/// <summary>
/// SSM mapper
/// </summary>
internal class VariantMapper : VariantMapper<Variant>
{
    public override string TableName => "SSMs";


    public override void Configure(EntityTypeBuilder<Variant> entity)
    {
        base.Configure(entity);


        entity.HasAlternateKey(variant => variant.Code);

        entity.Property(variant => variant.Code)
              .IsRequired()
              .HasMaxLength(500);

        entity.Property(variant => variant.TypeId)
              .IsRequired()
              .HasConversion<int>();

        entity.Property(variant => variant.ReferenceBase)
              .HasMaxLength(200);

        entity.Property(variant => variant.AlternateBase)
              .HasMaxLength(200);


        entity.HasOne<EnumValue<SsmType>>()
              .WithMany()
              .HasForeignKey(variant => variant.TypeId);
    }
}
