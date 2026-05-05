using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class MethylationSubtypeMapper : IEntityTypeConfiguration<EnumEntity<MethylationSubtype>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<MethylationSubtype>> entity)
    {
        var data = Enum.GetValues<MethylationSubtype>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("methylation_subtype", DomainDbSchemaNames.Specimens, data);
    }
}
