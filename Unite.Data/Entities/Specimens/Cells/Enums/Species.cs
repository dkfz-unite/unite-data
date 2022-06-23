using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Cells.Enums;

public enum Species
{
    [EnumMember(Value = "Human")]
    Human = 1,

    [EnumMember(Value = "Mouse")]
    Mouse = 2
}
