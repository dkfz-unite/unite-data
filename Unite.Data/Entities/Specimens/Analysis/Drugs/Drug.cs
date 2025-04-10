using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Specimens.Analysis.Drugs;

public record Drug : Base.Entity
{
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
}
