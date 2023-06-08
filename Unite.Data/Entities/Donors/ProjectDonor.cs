namespace Unite.Data.Entities.Donors;

public record ProjectDonor
{
    public int DonorId { get; set; }
    public int ProjectId { get; set; }

    public virtual Donor Donor { get; set; }
    public virtual Project Project { get; set; }
}
