using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Specimens.Materials;

public record MaterialSource
{
    [Column("id")]
    public int Id { get; set; }

    [Column("value")]
    public string Value { get; set; }
}
