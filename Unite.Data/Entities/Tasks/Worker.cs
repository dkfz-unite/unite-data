using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Entities.Tasks;

public class Worker
{
    public int Id { get; set; }
    public WorkerType TypeId { get; set; }
    public bool Active { get; set; }
}
