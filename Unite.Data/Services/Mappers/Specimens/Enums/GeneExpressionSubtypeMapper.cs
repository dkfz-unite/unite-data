using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Enums
{
    internal class GeneExpressionSubtypeMapper : IEntityTypeConfiguration<EnumValue<GeneExpressionSubtype>>
    {
        public void Configure(EntityTypeBuilder<EnumValue<GeneExpressionSubtype>> entity)
        {
            var data = new EnumValue<GeneExpressionSubtype>[]
            {
                GeneExpressionSubtype.Classical.ToEnumValue(),
                GeneExpressionSubtype.Mesenchymal.ToEnumValue(),
                GeneExpressionSubtype.Proneural.ToEnumValue()
            };

            entity.BuildEnumEntity("GeneExpressionSubtypes", DomainDbSchemaNames.Specimens, data);
        }
    }
}
