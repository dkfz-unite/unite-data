using System;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Entities.Tasks;

public class Task
{
    public long Id { get; set; }
    public TaskType TypeId { get; set; }
    public TaskTargetType TargetTypeId { get; set; }
    public string Target { get; set; }
    public string Data { get; set; }
    public DateTime Date { get; set; }
}
