using System.Runtime.Serialization;

namespace Unite.Data.Entities.Images.Enums;

public enum ImageType
{
    [EnumMember(Value = "MR")]
    MR = 1,

    [EnumMember(Value = "CT")]
    CT = 2
}
