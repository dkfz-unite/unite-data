using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Donors;

public record ProjectDonor
{
    [Column("donor_id")]
    public int DonorId { get; set; }
    [Column("project_id")]
    public int ProjectId { get; set; }

    public virtual Donor Donor { get; set; }
    public virtual Project Project { get; set; }
}
