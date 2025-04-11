using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Specimens.Organoids;

public record Organoid
{
    [Column("specimen_id")]
    public int SpecimenId { get; set; }

    [Column("implanted_cells_number")]
    public int? ImplantedCellsNumber { get; set; }
    [Column("tumorigenicity")]
    public bool? Tumorigenicity { get; set; }
    [Column("medium")]
    public string Medium { get; set; }


    public virtual Specimen Specimen { get; set; }
}
