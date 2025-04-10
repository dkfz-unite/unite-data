using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Entities.Tasks;

public record Worker
{
    [Column("id")]
    public int Id { get; set; }
    [Column("type_id")]
    public WorkerType TypeId { get; set; }
    [Column("active")]
    public bool Active { get; set; }
}
