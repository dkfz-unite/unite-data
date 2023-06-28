namespace Unite.Data.Entities.Specimens.Xenografts;

public record Intervention
{
    public int Id { get; set; }

    public int SpecimenId { get; set; }

    public int TypeId { get; set; }

    public string Details { get; set; }

    public DateOnly? StartDate { get; set; }
    public int? StartDay { get; set; }

    public DateOnly? EndDate { get; set; }
    public int? DurationDays { get; set; }

    public string Results { get; set; }


    public virtual Xenograft Xenograft { get; set; }
    public virtual InterventionType Type { get; set; }
}
