using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Donors.Clinical;

public record Treatment
{
    [Column("donor_id")]
    public int DonorId { get; set; }
    [Column("therapy_id")]
    public int TherapyId { get; set; }

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

    public virtual Donor Donor { get; set; }
    public virtual Therapy Therapy { get; set; }
}
