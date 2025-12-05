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
        var data = new EnumEntity<ExpressionSubtype>[]
        {
            ExpressionSubtype.Classical.ToEnumValue(),
            ExpressionSubtype.Mesenchymal.ToEnumValue(),
            ExpressionSubtype.Proneural.ToEnumValue()
        };

        entity.BuildEnumEntity("expression_subtype", DomainDbSchemaNames.Specimens, data);
    }
}
