using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Cells.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Cells.Enums;

internal class SpeciesMapper : IEntityTypeConfiguration<EnumEntity<Species>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<Species>> entity)
    {
        var data = new EnumEntity<Species>[]
        {
            Species.Human.ToEnumValue(),
            Species.Mouse.ToEnumValue()
        };

        entity.BuildEnumEntity("Species", DomainDbSchemaNames.Specimens, data);
    }
}
