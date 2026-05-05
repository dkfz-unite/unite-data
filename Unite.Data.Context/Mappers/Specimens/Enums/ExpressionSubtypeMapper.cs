using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class ExpressionSubtypeMapper : IEntityTypeConfiguration<EnumEntity<ExpressionSubtype>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<ExpressionSubtype>> entity)
    {
        var data = Enum.GetValues<ExpressionSubtype>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("expression_subtype", DomainDbSchemaNames.Specimens, data);
    }
}
