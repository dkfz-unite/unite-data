using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Enums;

public enum Condition
{
    [EnumMember(Value = "Normal")]
    Normal = 1,

    [EnumMember(Value = "Tumor")]
    Tumor = 2
}
