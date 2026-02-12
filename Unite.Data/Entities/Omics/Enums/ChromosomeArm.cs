using System.Runtime.Serialization;

namespace Unite.Data.Entities.Omics.Enums;

public enum ChromosomeArm
{
    [EnumMember(Value = "1")]
    Short = 1,
    [EnumMember(Value = "2")]
    Long = 2
}