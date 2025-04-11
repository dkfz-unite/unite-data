using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Donors;

public record Project
{
    public const string DefaultName = "Other";

    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }

    public virtual ICollection<ProjectDonor> ProjectDonors { get; set; }
}
