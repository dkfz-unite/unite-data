using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Specimens.Lines.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Lines.Enums;

internal class CellsSpeciesMapper : EnumEntityMapper<CellsSpecies>
{
    protected override string TableName => "cells_species";
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
}
