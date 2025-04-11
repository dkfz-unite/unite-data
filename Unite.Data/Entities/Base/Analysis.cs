using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Base;

public abstract record Analysis
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public DateOnly? Date { get; set; }
    [Column("day")]
    public int? Day { get; set; }

    [Column("parameters")]
    public Dictionary<string, string> Parameters { get; set; }   
}

public abstract record Analysis<TType> : Analysis
    where TType : struct, Enum
{
    [Column("type_id")]
    public TType TypeId { get; set; }
}
