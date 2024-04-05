using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

public enum WorkerType
{
    [EnumMember(Value = "Submission")]
    Submission = 1,

    [EnumMember(Value = "Annotation")]
    Annotation = 2,

    [EnumMember(Value = "Indexing")]
    Indexing = 3
}
