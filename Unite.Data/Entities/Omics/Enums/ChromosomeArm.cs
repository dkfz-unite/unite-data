using System.Runtime.Serialization;

namespace Unite.Data.Entities.Omics.Enums;

public enum ChromosomeArm
{
    [EnumMember(Value = "Short")]
    Short,
    [EnumMember(Value = "Long")]
    Long
}