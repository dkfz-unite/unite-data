using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Materials.Enums;

public enum FixationType
{
    [EnumMember(Value = "FFPE")]
    FFPE = 1,

    [EnumMember(Value = "Fresh_Frozen")]
    FreshFrozen = 2
}
