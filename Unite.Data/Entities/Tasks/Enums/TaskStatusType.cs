using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

public enum TaskStatusType
{
    /// <summary>
    /// Created task.
    /// </summary>
    [EnumMember(Value = "Created")]
    Created = 1, 

    /// <summary>
    /// Preparing of the task.
    /// </summary>
    [EnumMember(Value = "Preparing")]
    Preparing = 2,

    /// <summary>
    /// Processing of the task.
    /// </summary>
    [EnumMember(Value = "Processing")]
    Processing = 3,

    /// <summary>
    /// Completed task.
    /// </summary>
    [EnumMember(Value = "Completed")]
    Completed = 4
}
