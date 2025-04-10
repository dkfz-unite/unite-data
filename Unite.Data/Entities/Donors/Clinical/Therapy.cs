using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Donors.Clinical;

public record Therapy
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
}
