using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Genome.Variants.SV.Enums;

namespace Unite.Data.Context.Mappers.Genome.Variants.SV.Enums;

internal class SvTypeMapper : IEntityTypeConfiguration<EnumEntity<SvType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<SvType>> entity)
    {
        var data = new EnumEntity<SvType>[]
        {
            SvType.DUP.ToEnumValue(name: "Duplication"),
            SvType.TDUP.ToEnumValue(name: "Tandem duplication"),
            SvType.INS.ToEnumValue(name: "Insertion"),
            SvType.DEL.ToEnumValue(name: "Deletion"),
            SvType.INV.ToEnumValue(name: "Inversion"),
            SvType.ITX.ToEnumValue(name: "Intra-choromosmal translocation"),
            SvType.CTX.ToEnumValue(name: "Inter-chromosomal translocation"),
            SvType.COM.ToEnumValue(name: "Complex"),
        };

        entity.BuildEnumEntity("SvTypes", DomainDbSchemaNames.Genome, data);
    }
}
