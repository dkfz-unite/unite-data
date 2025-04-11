using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Specimens.Lines.Enums;

namespace Unite.Data.Entities.Specimens.Lines;

public record Line
{
    [Column("specimen_id")]
    public int SpecimenId { get; set; }

    [Column("cells_species_id")]
    public CellsSpecies? CellsSpeciesId { get; set; }
    [Column("cells_type_id")]
    public CellsType? CellsTypeId { get; set; }
    [Column("cells_culture_type_id")]
    public CellsCultureType? CellsCultureTypeId { get; set; }


    public virtual Specimen Specimen { get; set; }
    public virtual LineInfo Info { get; set; }
}
