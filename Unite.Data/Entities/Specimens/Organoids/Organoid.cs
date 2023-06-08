namespace Unite.Data.Entities.Specimens.Organoids;

public record Organoid
{
    public int SpecimenId { get; set; }
    public string ReferenceId { get; set; }

    public int? ImplantedCellsNumber { get; set; }
    public bool? Tumorigenicity { get; set; }
    public string Medium { get; set; }

    public virtual ICollection<Intervention> Interventions { get; set; }
}
