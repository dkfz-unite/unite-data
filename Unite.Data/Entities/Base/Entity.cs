using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Base;

public abstract record Entity
{
    [Column("id")]
    public int Id { get; set; }
}
