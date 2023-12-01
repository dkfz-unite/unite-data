using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class GeneExpressionSubtypeMapper : IEntityTypeConfiguration<EnumEntity<GeneExpressionSubtype>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<GeneExpressionSubtype>> entity)
    {
        var data = new EnumEntity<GeneExpressionSubtype>[]
        {
            GeneExpressionSubtype.Classical.ToEnumValue(),
            GeneExpressionSubtype.Mesenchymal.ToEnumValue(),
            GeneExpressionSubtype.Proneural.ToEnumValue()
        };

        entity.BuildEnumEntity("GeneExpressionSubtypes", DomainDbSchemaNames.Specimens, data);
    }
}
