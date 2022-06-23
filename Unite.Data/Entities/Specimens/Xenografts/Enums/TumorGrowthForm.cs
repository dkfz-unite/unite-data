using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Xenografts.Enums;

public enum TumorGrowthForm
{
    [EnumMember(Value = "Encapsulated")]
    Encapsulated = 1,

    [EnumMember(Value = "Invasive")]
    Invasive = 2
}
