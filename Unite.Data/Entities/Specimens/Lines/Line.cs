using Unite.Data.Entities.Specimens.Lines.Enums;

namespace Unite.Data.Entities.Specimens.Lines;

public record Line
{
    public int SpecimenId { get; set; }

    public CellsSpecies? CellsSpeciesId { get; set; }
    public CellsType? CellsTypeId { get; set; }
    public CellsCultureType? CellsCultureTypeId { get; set; }


    public virtual Specimen Specimen { get; set; }
    public virtual LineInfo Info { get; set; }
}
