using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Genome.Analysis.Dna.Cnv;
using Unite.Data.Entities.Genome.Analysis.Dna.Cnv.Enums;

namespace Unite.Data.Context.Mappers.Genome.Analysis.Dna.Cnv;

/// <summary>
/// CNV mapper
/// </summary>
internal class VariantMapper : VariantMapper<Variant>
{
    protected override string TableName => "Cnvs";

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
