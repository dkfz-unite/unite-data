using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Tissues.Enums;

public enum TissueType
{
    [EnumMember(Value = "Control")]
    Control = 1,

    [EnumMember(Value = "Tumor")]
    Tumor = 2
}
