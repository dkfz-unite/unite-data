using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Specimens.Xenografts.Enums;

namespace Unite.Data.Entities.Specimens.Xenografts;

public record Xenograft
{
    [Column("specimen_id")]
    public int SpecimenId { get; set; }

    [Column("mouse_strain")]
    public string MouseStrain { get; set; }
    [Column("group_size")]
    public int? GroupSize { get; set; }
    [Column("implant_type_id")]
    public ImplantType? ImplantTypeId { get; set; }
    [Column("implant_location_id")]
    public ImplantLocation? ImplantLocationId { get; set; }
    [Column("implanted_cells_number")]
    public int? ImplantedCellsNumber { get; set; }
    [Column("tumorigenicity")]
    public bool? Tumorigenicity { get; set; }
    [Column("tumor_growth_form_id")]
    public TumorGrowthForm? TumorGrowthFormId { get; set; }
    [Column("survival_days_from")]
    public int? SurvivalDaysFrom { get; set; }
    [Column("survival_days_to")]
    public int? SurvivalDaysTo { get; set; }


    public virtual Specimen Specimen { get; set; }
}
