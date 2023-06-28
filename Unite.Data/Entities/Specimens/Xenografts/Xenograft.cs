using Unite.Data.Entities.Specimens.Xenografts.Enums;

namespace Unite.Data.Entities.Specimens.Xenografts;

public record Xenograft
{
    public int SpecimenId { get; set; }
    public string ReferenceId { get; set; }

    public string MouseStrain { get; set; }
    public int? GroupSize { get; set; }
    public ImplantType? ImplantTypeId { get; set; }
    public TissueLocation? TissueLocationId { get; set; }
    public int? ImplantedCellsNumber { get; set; }
    public bool? Tumorigenicity { get; set; }
    public TumorGrowthForm? TumorGrowthFormId { get; set; }
    public int? SurvivalDaysFrom { get; set; }
    public int? SurvivalDaysTo { get; set; }


    public virtual Specimen Specimen { get; set; }
    public virtual ICollection<Intervention> Interventions { get; set; }
}
