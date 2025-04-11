using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Donors;

public record StudyDonor
{
    [Column("donor_id")]
    public int DonorId { get; set; }
    [Column("study_id")]
    public int StudyId { get; set; }

    public virtual Donor Donor { get; set; }
    public virtual Study Study { get; set; }
}
