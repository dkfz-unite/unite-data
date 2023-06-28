namespace Unite.Data.Entities.Donors.Clinical;

public record Treatment
{
    public int Id { get; set; }

    public int DonorId { get; set; }
    public int TherapyId { get; set; }

    public string Details { get; set; }

    public DateOnly? StartDate { get; set; }
    public int? StartDay { get; set; }

    public DateOnly? EndDate { get; set; }
    public int? DurationDays { get; set; }

    public string Results { get; set; }


    public virtual Donor Donor { get; set; }
    public virtual Therapy Therapy { get; set; }
}
