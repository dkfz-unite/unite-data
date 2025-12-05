using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Enums;

public enum TumorType
{
    [EnumMember(Value = "Primary")]
    Primary = 1,

    [EnumMember(Value = "Metastasis")]
    Metastasis = 2,

    [EnumMember(Value = "Recurrent")]
    Recurrent = 3
}
