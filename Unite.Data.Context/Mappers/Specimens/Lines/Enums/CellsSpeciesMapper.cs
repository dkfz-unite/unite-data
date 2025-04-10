using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Lines.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Lines.Enums;

internal class CellsSpeciesMapper : IEntityTypeConfiguration<EnumEntity<CellsSpecies>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<CellsSpecies>> entity)
    {
        var data = new EnumEntity<CellsSpecies>[]
        {
            CellsSpecies.Human.ToEnumValue(),
            CellsSpecies.Mouse.ToEnumValue()
        };

        entity.BuildEnumEntity("cells_species", DomainDbSchemaNames.Specimens, data);
    }
}
