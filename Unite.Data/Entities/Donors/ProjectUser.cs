using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Donors;

public class ProjectUser
{
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("project_id")]
    public int ProjectId { get; set; }

    public virtual DataUser User { get; set; }
    public virtual Project Project { get; set; }
}