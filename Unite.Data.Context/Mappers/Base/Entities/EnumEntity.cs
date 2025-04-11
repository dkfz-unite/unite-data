using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Context.Mappers.Base.Entities;

internal record EnumEntity<T> where T : Enum
{
    [Column("id")]
    public T Id { get; set; }
    [Column("value")]
    public string Value { get; set; }
    [Column("name")]
    public string Name { get; set; }
}
