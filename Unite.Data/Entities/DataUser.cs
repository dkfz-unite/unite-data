using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Entities;

public class DataUser
{
    [Column("id")]
    public int Id { get; set; }
    [Column("user_id")]
    public int UserId { get; set; }
    
    public virtual ICollection<ProjectUser> UserProjects { get; set; }
}