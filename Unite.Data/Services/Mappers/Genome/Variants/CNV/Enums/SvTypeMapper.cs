using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.CNV.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Genome.Variants.CNV.Enums;


internal class SvTypeMapper : IEntityTypeConfiguration<EnumValue<SvType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<SvType>> entity)
    {
        var data = new EnumValue<SvType>[]
        {
            SvType.DUP.ToEnumValue(name: "Duplication"),
            SvType.DEL.ToEnumValue(name: "Deletion"),
            SvType.ITX.ToEnumValue(name: "Intra-choromosmal translocation"),
            SvType.CTX.ToEnumValue(name: "Inter-chromosomal translocation")
        };

        entity.BuildEnumEntity("CnvSvTypes", DomainDbSchemaNames.Genome, data);
    }
}
