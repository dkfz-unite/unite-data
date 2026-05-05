using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Omics.Analysis.Dna.Sm.Enums;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Sm.Enums;

internal class SmTypeMapper : IEntityTypeConfiguration<EnumEntity<SmType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<SmType>> entity)
    {
        var data = Enum.GetValues<SmType>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("sm_type", DomainDbSchemaNames.Omics, data);
    }
}
