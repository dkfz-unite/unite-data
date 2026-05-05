using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Omics.Analysis.Dna.Sv.Enums;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Sv.Enums;

internal class SvTypeMapper : IEntityTypeConfiguration<EnumEntity<SvType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<SvType>> entity)
    {
        var data = Enum.GetValues<SvType>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("sv_type", DomainDbSchemaNames.Omics, data);
    }
}
