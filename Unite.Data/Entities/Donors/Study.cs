using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Donors;

public record Study
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }

    public ICollection<StudyDonor> StudyDonors { get; set; }
}
