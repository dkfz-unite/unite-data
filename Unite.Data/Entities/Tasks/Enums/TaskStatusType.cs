using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

public enum TaskStatusType
{
    /// <summary>
    /// Preparing the task for processing.
    /// </summary>
    [EnumMember(Value = "Preparing")]
    Preparing = 1, 

    /// <summary>
    /// Prepared the task for processing.
    /// </summary>
    [EnumMember(Value = "Prepared")]
    Prepared = 2,

    /// <summary>
    /// Processing the task.
    /// </summary>
    [EnumMember(Value = "Processing")]
    Processing = 3,

    /// <summary>
    /// Processed task.
    /// </summary>
    [EnumMember(Value = "Processed")]
    Processed = 4,

    /// <summary>
    /// Failed task.
    /// </summary>
    [EnumMember(Value = "Failed")]
    Failed = 5,

    /// <summary>
    /// Rejected task.
    /// </summary>
    [EnumMember(Value = "Rejected")]
    Rejected = 6
}
