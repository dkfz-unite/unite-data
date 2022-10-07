using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.SV.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Genome.Variants.SV.Enums;

internal class SvTypeMapper : IEntityTypeConfiguration<EnumValue<SvType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<SvType>> entity)
    {
        var data = new EnumValue<SvType>[]
        {
            SvType.DUP.ToEnumValue(name: "Duplication"),
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
