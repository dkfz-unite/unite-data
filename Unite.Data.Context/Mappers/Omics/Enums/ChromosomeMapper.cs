using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Context.Mappers.Omics.Enums;

internal class ChromosomeMapper : IEntityTypeConfiguration<EnumEntity<Chromosome>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<Chromosome>> entity)
    {
        var data = Enum.GetValues<Chromosome>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("chromosome", DomainDbSchemaNames.Omics, data);
    }
}
