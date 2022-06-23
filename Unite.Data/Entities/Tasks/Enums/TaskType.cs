using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

public enum TaskType
{
    [EnumMember(Value = "Indexing")]
    Indexing = 1,

    [EnumMember(Value = "Anotation")]
    Annotation = 2
}
