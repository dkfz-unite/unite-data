using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Omics.Analysis.Dna.Cnv.Enums;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Cnv.Enums;

internal class CnvTypeMapper : IEntityTypeConfiguration<EnumEntity<CnvType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<CnvType>> entity)
    {
        var data = Enum.GetValues<CnvType>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("cnv_type", DomainDbSchemaNames.Omics, data);
    }
}
