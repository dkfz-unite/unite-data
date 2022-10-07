namespace Unite.Data.Entities.Donors;

public class StudyDonor
{
    public int DonorId { get; set; }
    public int StudyId { get; set; }

    public virtual Donor Donor { get; set; }
    public virtual Study Study { get; set; }
}
