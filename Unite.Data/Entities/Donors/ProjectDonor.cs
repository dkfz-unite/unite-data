namespace Unite.Data.Entities.Donors;

public class ProjectDonor
{
    public int ProjectId { get; set; }
    public int DonorId { get; set; }

    public virtual Project Project { get; set; }
    public virtual Donor Donor { get; set; }
}
