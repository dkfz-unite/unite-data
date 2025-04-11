using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Specimens;

public record InterventionType
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
}
