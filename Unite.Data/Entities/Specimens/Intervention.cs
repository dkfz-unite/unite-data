using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Specimens;

public record Intervention
{
    [Column("specimen_id")]
    public int SpecimenId { get; set; }
    [Column("type_id")]
    public int TypeId { get; set; }

    [Column("details")]
    public string Details { get; set; }
    [Column("start_date")]
    public DateOnly? StartDate { get; set; }
    [Column("start_day")]
    public int? StartDay { get; set; }
    [Column("end_date")]
    public DateOnly? EndDate { get; set; }
    [Column("duration_days")]
    public int? DurationDays { get; set; }
    [Column("results")]
    public string Results { get; set; }

    public virtual Specimen Specimen { get; set; }
    public virtual InterventionType Type { get; set; }
}
